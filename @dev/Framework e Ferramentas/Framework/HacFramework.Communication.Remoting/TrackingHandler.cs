using System;
using System.IO;
using System.Collections.Generic;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting.Channels.Http;
using System.Runtime.Remoting.Services;
using System.Reflection;
using System.Text;

namespace HospitalAnaCosta.Framework.Communication.Remoting
{
    public class TrackingHandler : ITrackingHandler
    {

        #region events
        public event ShowStatusInstanceEventHandler ShowStatusInstance;
        #endregion

        private static Dictionary<string, int> instance = new Dictionary<string, int>();
        // Called when the tracked object is marshaled.

        private static void ComputeInstance(string instanceName, int fator)
        {

            string key = instanceName.Substring(1, instanceName.IndexOf(",") - 1);

            if (!instance.ContainsKey(key))
            {
                instance.Add(key, 1);
            }
            else
            {
                instance[key] += fator;
            }
        }

        [System.Security.Permissions.SecurityPermissionAttribute(
         System.Security.Permissions.SecurityAction.LinkDemand,
         Flags = System.Security.Permissions.SecurityPermissionFlag.Infrastructure)]
        public void MarshaledObject(Object obj, ObjRef objRef)
        {

            if (objRef.TypeInfo != null)
            {
                ComputeInstance(objRef.TypeInfo.TypeName, +1);
            }

            FireShowStatusInstance();

            #region ignore
            /*// Notify the user of the marshal event.
            Console.WriteLine("Tracking: An instance of {0} was marshaled.",
                obj.ToString());

            // Print the channel information.
            if (objRef.ChannelInfo != null)
            {
                // Iterate over ChannelData.
                foreach (object data in objRef.ChannelInfo.ChannelData)
                {
                    if (data is ChannelDataStore)
                    {
                        // Print the URIs from the ChannelDataStore objects.
                        string[] uris = ((ChannelDataStore)data).ChannelUris;
                        foreach (string uri in uris)
                            Console.WriteLine("ChannelUri: " + uri);
                    }
                }
            }

            // Print the envoy information.
            if (objRef.EnvoyInfo != null)
                Console.WriteLine("EnvoyInfo: " + objRef.EnvoyInfo.ToString());

            // Print the type information.
            if (objRef.TypeInfo != null)
            {
                Console.WriteLine("TypeInfo: " + objRef.TypeInfo.ToString());
                Console.WriteLine("TypeName: " + objRef.TypeInfo.TypeName);
            }

            // Print the URI.
            if (objRef.URI != null)
                Console.WriteLine("URI: " + objRef.URI.ToString());*/
            #endregion
        }

        protected void FireShowStatusInstance()
        {
            InstanceEventArgs instanceEventArgs = new InstanceEventArgs();
            instanceEventArgs.Instance = instance;
            OnShowStatusInstance(instanceEventArgs);
        }

        protected virtual void OnShowStatusInstance(InstanceEventArgs e)
        {
            if (ShowStatusInstance != null)
            { ShowStatusInstance(e); }
        }

        // Called when the tracked object is unmarshaled.
        [System.Security.Permissions.SecurityPermissionAttribute(
         System.Security.Permissions.SecurityAction.LinkDemand,
         Flags = System.Security.Permissions.SecurityPermissionFlag.Infrastructure)]
        public void UnmarshaledObject(Object obj, ObjRef objRef)
        {
            if (objRef.TypeInfo != null)
            {
                ComputeInstance(objRef.TypeInfo.TypeName, -1);
            }
            FireShowStatusInstance();
        }

        // Called when the tracked object is disconnected.
        [System.Security.Permissions.SecurityPermissionAttribute(
         System.Security.Permissions.SecurityAction.LinkDemand,
         Flags = System.Security.Permissions.SecurityPermissionFlag.Infrastructure)]
        public void DisconnectedObject(Object obj)
        {

            ComputeInstance(obj.GetType().FullName + ",", -1);

            FireShowStatusInstance();
        }
    }
}
