using System;
using System.IO;
using System.Collections.Generic;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting.Channels.Http;
using System.Runtime.Remoting.Services;
using System.Threading;
using System.Reflection;
using System.Text;
using HacFramework.Communication.Remoting;

namespace HospitalAnaCosta.Framework.Communication.Remoting
{
    public abstract class Server
    {
        #region Attributos
        Dictionary<string, string> namespaceExpose = new Dictionary<string, string>();
        Dictionary<string, string> classExclude = new Dictionary<string, string>();
        Dictionary<string, string> classPatern = new Dictionary<string, string>();
        Dictionary<string, string> pathBin = new Dictionary<string, string>();
        Dictionary<string, Type> typeToLoad = new Dictionary<string, Type>();
        Dictionary<string, string> assemblyToLoad = new Dictionary<string, string>();
        bool customErrorMode = false;
        bool trackInfo = true;
        #endregion

        #region Propriedades

        /// <summary>
        /// Habilita a informacao de tracking de informacao
        /// </summary>
        protected bool TrackInfo
        {
            get { return trackInfo; }
            set { trackInfo = value; }
        }

        /// <summary>
        /// Configura o servidor para enviar mensagens de erro para o cliente
        /// </summary>
        protected bool CustomErrorMode
        {
            get { return customErrorMode; }
            set { customErrorMode = value; }
        }

        /// <summary>
        /// Lista os nomes dos assemblys que devem ser carregados
        /// </summary>
        protected Dictionary<string, string> AssemblyToLoad
        {
            get { return assemblyToLoad; }
            set { assemblyToLoad = value; }
        }

        /// <summary>
        /// Colecao dos names spaces que devem ser expostos pelo servidor. Todas as classes que pertencem a este serao expotas. Inclui os sub divisoes
        /// </summary>
        protected Dictionary<string, string> NamespaceExpose
        {
            get { return namespaceExpose; }
            set { namespaceExpose = value; }
        }

        /// <summary>
        /// Classes que nao devem ser expostas pelo servidor
        /// </summary>
        protected Dictionary<string, string> ClassExclude
        {
            get { return classExclude; }
            set { classExclude = value; }
        }

        /// <summary>
        /// Caso necessarios, somente expoe classes que derivam de determinado classe pai
        /// </summary>
        protected Dictionary<string, string> ClassPatern
        {
            get { return classPatern; }
            set { classPatern = value; }
        }

        /// <summary>
        /// define os caminhos das assemblies para exposicao
        /// </summary>
        public Dictionary<string, string> PathBin
        {
            get { return pathBin; }
            set { pathBin = value; }
        }

        #endregion

        #region Eventos
        public event ShowStatusEventHandler ShowStatus;
        public event ShowStatusInstanceEventHandler ShowStatusInstance;
        #endregion

        #region Construtor
        public Server()
        {

        }
        #endregion

        #region Metodos
        /// <summary>
        /// OnShowStatus
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnShowStatus(StatusEventArgs e)
        {

            if (ShowStatus != null)
            {
                ParameterizedThreadStart parameterizedThreadStart = new ParameterizedThreadStart(OnShowStatusThread);
                Thread thread = new Thread(parameterizedThreadStart);
                thread.Start(e);
            }
        }

        /// <summary>
        /// Dispara o evento atraves de uma thread
        /// </summary>
        /// <param name="e"></param>
        private void OnShowStatusThread(object e)
        {
            ShowStatus((StatusEventArgs)e);
        }
        /// <summary>
        /// OnShowStatusInstance
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnShowStatusInstance(InstanceEventArgs e)
        {
            if (ShowStatusInstance != null)
            {
                ParameterizedThreadStart parameterizedThreadStart = new ParameterizedThreadStart(OnShowStatusInstanceThread);
                Thread thread = new Thread(parameterizedThreadStart);
                thread.Start(e);
            }
        }


        private void OnShowStatusInstanceThread(object e)
        {
            ShowStatusInstance((InstanceEventArgs)e);
        }


        private void DisplayStatus(string message, object detail)
        {
            StatusEventArgs statusEventArgs = new StatusEventArgs();
            statusEventArgs.StatusMessage = string.Format(message, detail);
            OnShowStatus(statusEventArgs);
        }

        private void DisplayStatus(string message, object detail1, object detail2)
        {
            StatusEventArgs statusEventArgs = new StatusEventArgs();
            statusEventArgs.StatusMessage = string.Format(message, detail1, detail2);
            OnShowStatus(statusEventArgs);
        }


        private void DisplayStatus(string message)
        {
            DisplayStatus(message, null);
        }

        /// <summary>
        /// Adiciona os canais de comunicacao usados pela aplicacao
        /// </summary>
        /// <param name="port"></param>
        /// <param name="channelType"></param>
        protected void AddChannel(int port, ChannelType channelType)
        {
            DisplayStatus(Message.CreatingChannel, channelType.ToString(), port);
            IChannel channel = Common.CreateChannel(port, channelType);

            // verifica se o canal ja existe um canal com essas especificacoes
            try
            {
                ChannelServices.RegisterChannel(channel, false);
            }
            catch
            {

            }

            //foreach (IChannel registeredChannel in ChannelServices.RegisteredChannels)
            //{
            //    //  registeredChannel.
            //}

            DisplayStatus(Message.ChannelCreated, channelType.ToString());

        }

        /// <summary>
        /// Disponibiliza as entidades  nos cainais disponibilizados
        /// </summary>
        /// <param name="types"></param>    
        public void StartListen()
        {
            //verifica se deve fazer o track de informacoes
            if (trackInfo)
            {
                ConfigureTrackInfo();
            }

            //RemotingConfiguration.CustomErrorsEnabled(this.customErrorMode);
            RemotingConfiguration.CustomErrorsMode = CustomErrorsModes.Off;

            DisplayStatus(Message.LoadingClasses);
            foreach (KeyValuePair<string, Type> typeToLoad in this.typeToLoad)
            {
                System.Type type = typeToLoad.Value;
                if (type.GetInterfaces().Length > 0)
                {
                    DisplayStatus(Message.LoadClassOK, type.FullName);
                    RemotingConfiguration.RegisterWellKnownServiceType(type, type.FullName, WellKnownObjectMode.SingleCall);
                }
            }
        }

        /// <summary>
        /// Faz a configuracao do trackservice
        /// </summary>
        private void ConfigureTrackInfo()
        {
            // Register a tracking handler.
            ITrackingHandler handler = new TrackingHandler();
            TrackingServices.RegisterTrackingHandler(handler);
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(TrackingHandler), typeof(TrackingHandler).FullName, WellKnownObjectMode.SingleCall);

            ((TrackingHandler)handler).ShowStatusInstance += new ShowStatusInstanceEventHandler(Server_ShowStatusInstance);

        }

        void Server_ShowStatusInstance(InstanceEventArgs args)
        {
            OnShowStatusInstance(args);
        }


        /// <summary>
        /// Faz o processo de configuracao do servidor
        /// </summary>
        protected void Configure()
        {


            //Carrega os assemblies
            LoadAssembly();

            // LoadTypes
            LoadTypes();
        }
        /// <summary>
        /// Faz a carga dos tipos
        /// </summary>
        protected void LoadTypes()
        {

            #region Old
            DisplayStatus(Message.AssemblyMessage);
            foreach (KeyValuePair<string, string> assemblyName in this.assemblyToLoad)
            {
                DisplayStatus(Message.AssemblyToLoad, assemblyName.Value);
                Assembly assembly = Assembly.Load(assemblyName.Value);//Assembly.LoadWithPartialName(assemblyName.Value);

                foreach (Type type in assembly.GetTypes())
                {
                    // verifica se o mesmo faz parte dos namespaces que devem ser importados
                    foreach (KeyValuePair<string, string> name in namespaceExpose)
                    {
                        if (type.FullName.StartsWith(name.Value))
                        {
                            bool cont = false;

                            if (this.classPatern.Count > 0)
                            {
                                // verifica se o tipo da classe 'e do tipo de patern
                                foreach (KeyValuePair<string, string> classPatern in this.classPatern)
                                {
                                    if (type.BaseType.FullName.Equals(classPatern.Value))
                                    {
                                        cont = true;
                                    }
                                }
                            }
                            else
                            {
                                cont = true;
                            }

                            if (!cont)
                            {
                                break;
                            }

                            foreach (KeyValuePair<string, string> classExcluide in this.classExclude)
                            {
                                if (type.FullName.Equals(classExcluide.Value))
                                {
                                    cont = false;
                                }
                            }
                            if (cont)
                            {
                                if (!this.typeToLoad.ContainsKey(type.FullName))
                                {
                                    this.typeToLoad.Add(type.FullName, type);
                                }

                            }
                        }
                    }
                }

            }
            #endregion
            #region new old
            /*
            foreach (KeyValuePair<string, string> name in namespaceExpose)
            {
                // verifica se o mesmo faz parte dos namespaces que devem ser importados
                Assembly assembly = Assembly.LoadWithPartialName(name.Value);

                foreach (Type type in assembly.GetTypes())
                {

                    bool cont = false;

                    if (this.classPatern.Count > 0)
                    {
                        // verifica se o tipo da classe 'e do tipo de patern
                        foreach (KeyValuePair<string, string> classPatern in this.classPatern)
                        {
                            if (type.BaseType.FullName.Equals(classPatern.Value))
                            {
                                cont = true;
                            }
                        }
                    }
                    else
                    {
                        cont = true;
                    }

                    if (!cont)
                    {
                        break;
                    }

                    foreach (KeyValuePair<string, string> classExcluide in this.classExclude)
                    {
                        if (type.FullName.Equals(classExcluide.Value))
                        {
                            cont = false;
                        }
                    }
                    if (cont)
                    {
                        if (!this.typeToLoad.ContainsKey(type.FullName))
                        {
                            this.typeToLoad.Add(type.FullName, type.FullName);
                        }

                    }

                }
            }
             * */
            #endregion
        }

        #region LoadAssembly
        /// <summary>
        /// Carrega as dll passadas como parametro
        /// </summary>
        protected void LoadAssembly()
        {
            foreach (KeyValuePair<string, string> path in pathBin)
            {
                LoadAssembly(path.Value);
            }
        }

        /// <summary>
        /// Faz a carga das dll passadas como parametro
        /// 
        protected Assembly LoadAssembly(string pathSearch)
        {
            return LoadAssembly(pathSearch, null);
        }

        /// <summary>
        /// Faz a carga das dll passadas como parametro
        /// </summary>
        /// <param name="pathSearch">Caminho das paginas
        /// </param>
        /// <param name="pathDLL"></param>
        /// <returns></returns>
        private Assembly LoadAssembly(string pathSearch, string pathDLL)
        {
            Assembly assembly = null;
            if (!string.IsNullOrEmpty(pathDLL))
            {
                assembly = Assembly.LoadFrom(pathDLL);
            }
            {
                foreach (string dll in Directory.GetFiles(pathSearch, "*.dll"))
                {
                    if (pathDLL.Length != 0)
                    {
                        // verifica se o assembly precisa do modulo carregado
                        //Assembly assemblyDependencia = Assembly.LoadFrom(dll);                  

                        AssemblyName assemblyNameDLL = AssemblyName.GetAssemblyName(dll);

                        foreach (AssemblyName an in assembly.GetReferencedAssemblies())
                        {
                            if (an.FullName.Equals(assemblyNameDLL.FullName))
                            {
                                LoadAssembly(pathSearch, dll);
                            }
                        }
                    }
                    else
                    {
                        LoadAssembly(pathSearch, dll);
                    }
                }
            }
            return assembly;
        }
        #endregion
        #endregion

    }




}
