﻿using System.Threading.Tasks;
using RawRabbit.Common.Serialization;

namespace RawRabbit.Common.Operations
{
	public abstract class SenderBase : OperatorBase
	{
		protected IMessageSerializer Serializer;

		protected SenderBase(IChannelFactory channelFactory, IMessageSerializer serializer) : base(channelFactory)
		{
			Serializer = serializer;
		}

		protected Task<byte[]> CreateMessageAsync<T>(T message)
		{
			return Task.Factory.StartNew(() => Serializer.Serialize(message));
		}

	}
}
