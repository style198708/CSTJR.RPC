/**
 * Autogenerated by Thrift Compiler (0.10.0)
 *
 * DO NOT EDIT UNLESS YOU ARE SURE THAT YOU KNOW WHAT YOU ARE DOING
 *  @generated
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Thrift;
using Thrift.Collections;
using System.Runtime.Serialization;
using Thrift.Protocol;
using Thrift.Transport;

namespace CSTJR.RPC.Member.Contracts
{

  #if !SILVERLIGHT
  [Serializable]
  #endif
  public partial class MemberImpressResult : TBase
  {
    private string _ImpressContent;
    private int _Count;

    public string ImpressContent
    {
      get
      {
        return _ImpressContent;
      }
      set
      {
        __isset.ImpressContent = true;
        this._ImpressContent = value;
      }
    }

    public int Count
    {
      get
      {
        return _Count;
      }
      set
      {
        __isset.Count = true;
        this._Count = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool ImpressContent;
      public bool Count;
    }

    public MemberImpressResult() {
    }

    public void Read (TProtocol iprot)
    {
      iprot.IncrementRecursionDepth();
      try
      {
        TField field;
        iprot.ReadStructBegin();
        while (true)
        {
          field = iprot.ReadFieldBegin();
          if (field.Type == TType.Stop) { 
            break;
          }
          switch (field.ID)
          {
            case 1:
              if (field.Type == TType.String) {
                ImpressContent = iprot.ReadString();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 2:
              if (field.Type == TType.I32) {
                Count = iprot.ReadI32();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            default: 
              TProtocolUtil.Skip(iprot, field.Type);
              break;
          }
          iprot.ReadFieldEnd();
        }
        iprot.ReadStructEnd();
      }
      finally
      {
        iprot.DecrementRecursionDepth();
      }
    }

    public void Write(TProtocol oprot) {
      oprot.IncrementRecursionDepth();
      try
      {
        TStruct struc = new TStruct("MemberImpressResult");
        oprot.WriteStructBegin(struc);
        TField field = new TField();
        if (ImpressContent != null && __isset.ImpressContent) {
          field.Name = "ImpressContent";
          field.Type = TType.String;
          field.ID = 1;
          oprot.WriteFieldBegin(field);
          oprot.WriteString(ImpressContent);
          oprot.WriteFieldEnd();
        }
        if (__isset.Count) {
          field.Name = "Count";
          field.Type = TType.I32;
          field.ID = 2;
          oprot.WriteFieldBegin(field);
          oprot.WriteI32(Count);
          oprot.WriteFieldEnd();
        }
        oprot.WriteFieldStop();
        oprot.WriteStructEnd();
      }
      finally
      {
        oprot.DecrementRecursionDepth();
      }
    }

    public override string ToString() {
      StringBuilder __sb = new StringBuilder("MemberImpressResult(");
      bool __first = true;
      if (ImpressContent != null && __isset.ImpressContent) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("ImpressContent: ");
        __sb.Append(ImpressContent);
      }
      if (__isset.Count) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Count: ");
        __sb.Append(Count);
      }
      __sb.Append(")");
      return __sb.ToString();
    }

  }

}
