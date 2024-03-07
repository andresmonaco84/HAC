using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Collections;

namespace HospitalAnaCosta.Framework
{
    /// <summary>
    /// Summary description for TreeHelper.
    /// </summary>
    [Serializable()]
    public class BaseTree : Object
    {
        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="filled">Preenche as sub-propriedades?</param>
        public BaseTree(bool filled)
        {
        }

        public bool Has(Type TreeToFind)
        {
            return this.IsInTree(TreeToFind);
        }

        public BaseTree Get(Type TreeToFind)
        {
            return this.GetTree(TreeToFind);
        }

        private BaseTree _seekTree;

        private BaseTree GetTree(Type TreeToFind)
        {
            _seekTree = null;
            findTree(this, TreeToFind);
            return _seekTree;
        }
        private bool IsInTree(Type TreeToFind)
        {
            _seekTree = null;
            findTree(this, TreeToFind);
            if (null != _seekTree) return true; else return false;
        }

        private void findTree(BaseTree TreeInstance, Type TreeToFind)
        {
            if (null != TreeInstance)
            {
                Type treeType = TreeInstance.GetType();

                if (treeType == TreeToFind)
                {
                    _seekTree = TreeInstance;
                    return;
                }
                else
                {
                    FieldInfo[] fields = treeType.GetFields();
                    foreach (FieldInfo field in fields)
                    {
                        if (field.FieldType.IsSubclassOf(typeof(BaseTree)))
                        {
                            if (field.FieldType == TreeToFind)
                            {
                                _seekTree = (BaseTree)field.GetValue(TreeInstance);
                                return;
                            }
                            else
                            {
                                findTree((BaseTree)field.GetValue(TreeInstance), TreeToFind);
                            }
                        }
                    }
                }
            }
        }

        public override string ToString()
        {
            return base.ToString();
        }

    }
}
