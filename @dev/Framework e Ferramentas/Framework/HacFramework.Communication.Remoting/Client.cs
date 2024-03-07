using System;
using System.Collections.Generic;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting.Channels.Http;
using System.Text;

namespace HospitalAnaCosta.Framework.Communication.Remoting
{
    public class Client
    {
        private string url;

        public string Url
        {
            get { return url; }
            set { url = value; }
        }


        /// <summary>
        /// Adiciona os canais de comunicacao usados pela aplicacao
        /// </summary>
        /// <param name="port"></param>
        /// <param name="channelType"></param>
        public void AddChannel(ChannelType channelType)
        {
            IChannel channel = Common.CreateChannel(channelType);

            // verifica se o canal ja existe um canal com essas especificacoes
            try
            {
                ChannelServices.RegisterChannel(channel, false);
            }
            catch
            {

            }
        }

        public object GetObject(Type type, string objectType)
        {
            return System.Activator.GetObject(type, url + objectType);
        }


    }
}
