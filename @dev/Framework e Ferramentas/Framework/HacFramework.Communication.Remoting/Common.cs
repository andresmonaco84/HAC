using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting.Channels.Http;
using System.Reflection;

namespace HospitalAnaCosta.Framework.Communication.Remoting
{

    internal abstract class Common
    {
        /// <summary>
        /// Cria o canal de acordo com os parametros passados
        /// </summary>
        /// <param name="port"></param>
        /// <param name="channelType"></param>
        /// <returns></returns>
        public static IChannel CreateChannel(int port, ChannelType channelType)
        {
            IChannel channel = null;

            switch (channelType)
            {
                case ChannelType.HTTP:
                    channel = new HttpChannel(port);
                    break;
                case ChannelType.TCP:
                    channel = new TcpChannel(port);
                    break;
            }

            return channel;
        }


        /// <summary>
        /// Cria o canal de acordo com os parametros passados
        /// </summary>
        /// <param name="port"></param>
        /// <param name="channelType"></param>
        /// <returns></returns>
        public static IChannel CreateChannel(ChannelType channelType)
        {
            IChannel channel = null;

            switch (channelType)
            {
                case ChannelType.HTTP:
                    channel = new HttpChannel();
                    break;
                case ChannelType.TCP:
                    channel = new TcpChannel();
                    break;
            }

            return channel;
        }
    }
}
