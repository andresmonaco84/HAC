// Copyright © 2004 by Christoph Richner. All rights are reserved.
// 
// If you like this code then feel free to go ahead and use it.
// The only thing I ask is that you don't remove or alter my copyright notice.
//
// Your use of this software is entirely at your own risk. I make no claims or
// warrantees about the reliability or fitness of this code for any particular purpose.
// If you make changes or additions to this code please mark your code as being yours.
// 
// website http://raccoom.sytes.net, email microweb@bluewin.ch, msn chrisdarebell@msn.com

using System;
using System.Windows.Forms;

namespace Hac.Windows.Forms.Controls
{
    /// <summary>
    /// The TreeViewStrategy is tree view which aggregates a tree view data provider interface (Strategy pattern).
    /// The goal of this design is to provide an easy way to extend or add data providers without changing
    /// a single line of tree view code. Basically the tree view interface will not change so far, but the 
    /// data providers will change their behavior and features.
    /// </summary>
    public partial class HacTreeViewOnDemand : System.Windows.Forms.TreeView
    {
        #region fields
        /// <summary>Fired if the datasource has changed</summary>		
        public EventHandler DataSourceChanged;
        /// <summary>The underlying data provider which is used to start requests.</summary>
        private IDataProvider _dataProvider;
        #endregion

        #region constructors
        /// <summary>
        /// Initializes a new instance of the TreeViewStrategy class.
        /// </summary>
        public HacTreeViewOnDemand()
        {
            // create the context menu and assing it to the tree view			 
            ContextMenu = new ContextMenu();
            ContextMenu.Popup += new EventHandler(ContextMenu_Popup);
        }
        #endregion

        #region public interface
        /// <summary>
        /// Gets or sets the <see cref="IDataProvider"/> which is responsible to manage this <see cref="TreeView"/> instance.
        /// </summary>
        public IDataProvider DataSource
        {
            get
            {
                return _dataProvider;
            }
            set
            {
                _dataProvider = value;
                // fire the DataSourceChanged event
                OnDataSourceChanged(EventArgs.Empty);
            }
        }
        /// <summary>
        /// Fill's the root level.
        /// </summary>
        public void Fill()
        {
            //System.Diagnostics.Debug.Assert(_dataProvider != null);
            // show wait cursor, maybe there is a longer operation on the data provider
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                // clear all nodes
                Nodes.Clear();
                // request the new root nodes
                _dataProvider.RequestRootNodes(this);
            }
            finally
            {
                // Make sure to reset the current cursor.
                // NOTE: There is no catch block, because we don't want to handle 
                // occured exceptions at this level, the user of this code is responsible
                // to manage it.
                Cursor.Current = Cursors.Default;
            }
        }
        #endregion

        #region protected interface
        /// <summary>
        /// Raises the DataSourceChanged event.
        /// </summary>
        /// <remarks>
        /// <b>Notes to Inheritors</b>: When overriding OnDataSourceChanged in a derived class, be sure to call the base class's OnDataSourceChanged method so that registered delegates receive the event. 
        /// </remarks>
        /// <param name="e"></param>
        protected virtual void OnDataSourceChanged(EventArgs e)
        {
            if (DataSourceChanged != null) DataSourceChanged(this, e);
        }
        /// <summary>
        /// Invokes the <see cref="IDataProvider.QueryContextMenuItems"/> method
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnContextMenuPopup(EventArgs e)
        {
            System.Diagnostics.Debug.Assert(_dataProvider != null);
            // retrieve node which was clicked
            TreeNodeBase node = GetNodeAt(PointToClient(Cursor.Position)) as TreeNodeBase;
            if (node == null) return;
            // clear previous items
            ContextMenu.MenuItems.Clear();
            // let the provider do his work
            _dataProvider.QueryContextMenuItems(this.ContextMenu, node);
        }
        /// <summary>
        /// Invokes the <see cref="IDataProvider.RequestNodes"/> method
        /// </summary>
        /// <param name="e"></param>
        protected override void OnBeforeExpand(TreeViewCancelEventArgs e)
        {
            // cast node back to our base type
            TreeNodeBase node = (TreeNodeBase)e.Node;
            System.Diagnostics.Debug.Assert(node != null);
            // fill expanded node if not filled at this time (on demand)
            if (node.HasDummyNode)
            {
                // remove dummy node before we fill the child nodes and let the node expand itself to show
                // it's children nodes
                node.RemoveDummyNode();
                //
                Cursor.Current = Cursors.WaitCursor;
                try
                {
                    // let the provider do his work
                    _dataProvider.RequestNodes(this, node, e);
                }
                finally
                {
                    Cursor.Current = Cursors.Default;
                }
            }
            //
            base.OnBeforeExpand(e);
        }
        #endregion

        #region private interface
        /// <summary>
        /// Fired by the <see cref="ContextMenu"/> before the shortcut menu is displayed.
        /// The private event handler is used to call the virtual protected method <see cref="OnContextMenuPopup"/>
        /// </summary>		
        private void ContextMenu_Popup(object sender, EventArgs e)
        {
            OnContextMenuPopup(e);
        }
        #endregion

    }
    /// <summary>
    /// TreeNodeBase inherit from <see cref="TreeNode"/> and provides methods to handle dummy child nodes for fill on demand operations.
    /// </summary>
    public class TreeNodeBase : TreeNode
    {
        #region constructors
        /// <summary>
        /// Initializes a new instance of the TreeNodeBase class.
        /// </summary>
        public TreeNodeBase(string text) : base(text) { }

        #endregion

        #region internal interface
        /// <summary>
        /// Gets a value indicating if this node owns a dummy node.
        /// </summary>
        public virtual bool HasDummyNode
        {
            get
            {
                return (Nodes.Count > 0 && Nodes[0].Text == "@@Dummy@@");
            }
        }
        /// <summary>
        /// Adds a dummy node to the parent node
        /// </summary>		
        public virtual void AddDummyNode()
        {
            Nodes.Add(new TreeNodeBase("@@Dummy@@"));
        }
        /// <summary>
        /// Removes the dummy node from the parent node.
        /// </summary>		
        public virtual void RemoveDummyNode()
        {
            if ((Nodes.Count == 1) & (Nodes[0].Text == "@@Dummy@@"))
            {
                Nodes[0].Remove();
            }
        }
        #endregion
    }
    /// <summary>
    /// DataProvider interface is based on <see cref="TreeViewStrategy"/> and <see cref="TreeNodeBase"/> and it is responsible to fill a <see cref="TreeViewStrategy"/> instance with the requested data.
    /// </summary>
    public interface IDataProvider
    {
        /// <summary>
        /// Request to fill the root nodes.
        /// </summary>
        /// <param name="treeView">The <see cref="TreeView"/> instance which start this request.</param>
        void RequestRootNodes(HacTreeViewOnDemand treeView);
        /// <summary>
        /// Request to fill child nodes.
        /// </summary>
        /// <param name="treeView">The <see cref="TreeView"/> instance which start this request.</param>
        /// <param name="node">The <see cref="TreeNodeBase"/> which acts as parent for the request child nodes.</param>
        /// <param name="e">Specifying whether the event is to be canceled, and the type of tree view action that raised the event.</param>
        void RequestNodes(HacTreeViewOnDemand treeView, TreeNodeBase node, TreeViewCancelEventArgs e);
        /// <summary>
        /// Request to fill a <see cref="ContextMenu"/> with <see cref="MenuItem"/>'s for the specified <see cref="TreeNode"/>.
        /// </summary>
        /// <param name="contextMenu">The ContextMenu instance to fill.</param>
        /// <param name="node">The node which request the context menu items.</param>		
        void QueryContextMenuItems(ContextMenu contextMenu, TreeNodeBase node);
    }
}
