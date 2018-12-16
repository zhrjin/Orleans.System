﻿using Orleans.Concurrency;
using ProtoBuf;
using Ray.Core;

namespace Ray.IGrains
{
    [ProtoContract(ImplicitFields = ImplicitFields.AllFields)]
    [Immutable]
    public class MessageInfo: IMessageWrapper
    {
        public string TypeName { get; set; }
        public byte[] Bytes { get; set; }
    }
}
