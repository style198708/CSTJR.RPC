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

namespace CSTJR.RPC.Product.Contracts
{

  #if !SILVERLIGHT
  [Serializable]
  #endif
  public partial class ProductListResult : TBase
  {
    private int _ProductID;
    private string _ProductName;
    private int _ProductType;
    private string _CategoryName;
    private string _CodeName;
    private string _ProductStatusType;
    private string _FundLogo;
    private string _CompanyName;
    private string _MemberName;
    private string _CreateTime;
    private string _ExtStr01;
    private string _ExtVaule01;
    private string _ExtStr02;
    private string _ExtVaule02;
    private string _ExtStr03;
    private string _ExtVaule03;
    private string _ExtStr04;
    private string _ExtVaule04;

    public int ProductID
    {
      get
      {
        return _ProductID;
      }
      set
      {
        __isset.ProductID = true;
        this._ProductID = value;
      }
    }

    public string ProductName
    {
      get
      {
        return _ProductName;
      }
      set
      {
        __isset.ProductName = true;
        this._ProductName = value;
      }
    }

    public int ProductType
    {
      get
      {
        return _ProductType;
      }
      set
      {
        __isset.ProductType = true;
        this._ProductType = value;
      }
    }

    public string CategoryName
    {
      get
      {
        return _CategoryName;
      }
      set
      {
        __isset.CategoryName = true;
        this._CategoryName = value;
      }
    }

    public string CodeName
    {
      get
      {
        return _CodeName;
      }
      set
      {
        __isset.CodeName = true;
        this._CodeName = value;
      }
    }

    public string ProductStatusType
    {
      get
      {
        return _ProductStatusType;
      }
      set
      {
        __isset.ProductStatusType = true;
        this._ProductStatusType = value;
      }
    }

    public string FundLogo
    {
      get
      {
        return _FundLogo;
      }
      set
      {
        __isset.FundLogo = true;
        this._FundLogo = value;
      }
    }

    public string CompanyName
    {
      get
      {
        return _CompanyName;
      }
      set
      {
        __isset.CompanyName = true;
        this._CompanyName = value;
      }
    }

    public string MemberName
    {
      get
      {
        return _MemberName;
      }
      set
      {
        __isset.MemberName = true;
        this._MemberName = value;
      }
    }

    public string CreateTime
    {
      get
      {
        return _CreateTime;
      }
      set
      {
        __isset.CreateTime = true;
        this._CreateTime = value;
      }
    }

    public string ExtStr01
    {
      get
      {
        return _ExtStr01;
      }
      set
      {
        __isset.ExtStr01 = true;
        this._ExtStr01 = value;
      }
    }

    public string ExtVaule01
    {
      get
      {
        return _ExtVaule01;
      }
      set
      {
        __isset.ExtVaule01 = true;
        this._ExtVaule01 = value;
      }
    }

    public string ExtStr02
    {
      get
      {
        return _ExtStr02;
      }
      set
      {
        __isset.ExtStr02 = true;
        this._ExtStr02 = value;
      }
    }

    public string ExtVaule02
    {
      get
      {
        return _ExtVaule02;
      }
      set
      {
        __isset.ExtVaule02 = true;
        this._ExtVaule02 = value;
      }
    }

    public string ExtStr03
    {
      get
      {
        return _ExtStr03;
      }
      set
      {
        __isset.ExtStr03 = true;
        this._ExtStr03 = value;
      }
    }

    public string ExtVaule03
    {
      get
      {
        return _ExtVaule03;
      }
      set
      {
        __isset.ExtVaule03 = true;
        this._ExtVaule03 = value;
      }
    }

    public string ExtStr04
    {
      get
      {
        return _ExtStr04;
      }
      set
      {
        __isset.ExtStr04 = true;
        this._ExtStr04 = value;
      }
    }

    public string ExtVaule04
    {
      get
      {
        return _ExtVaule04;
      }
      set
      {
        __isset.ExtVaule04 = true;
        this._ExtVaule04 = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool ProductID;
      public bool ProductName;
      public bool ProductType;
      public bool CategoryName;
      public bool CodeName;
      public bool ProductStatusType;
      public bool FundLogo;
      public bool CompanyName;
      public bool MemberName;
      public bool CreateTime;
      public bool ExtStr01;
      public bool ExtVaule01;
      public bool ExtStr02;
      public bool ExtVaule02;
      public bool ExtStr03;
      public bool ExtVaule03;
      public bool ExtStr04;
      public bool ExtVaule04;
    }

    public ProductListResult() {
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
              if (field.Type == TType.I32) {
                ProductID = iprot.ReadI32();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 2:
              if (field.Type == TType.String) {
                ProductName = iprot.ReadString();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 3:
              if (field.Type == TType.I32) {
                ProductType = iprot.ReadI32();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 4:
              if (field.Type == TType.String) {
                CategoryName = iprot.ReadString();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 5:
              if (field.Type == TType.String) {
                CodeName = iprot.ReadString();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 6:
              if (field.Type == TType.String) {
                ProductStatusType = iprot.ReadString();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 7:
              if (field.Type == TType.String) {
                FundLogo = iprot.ReadString();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 8:
              if (field.Type == TType.String) {
                CompanyName = iprot.ReadString();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 9:
              if (field.Type == TType.String) {
                MemberName = iprot.ReadString();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 10:
              if (field.Type == TType.String) {
                CreateTime = iprot.ReadString();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 11:
              if (field.Type == TType.String) {
                ExtStr01 = iprot.ReadString();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 12:
              if (field.Type == TType.String) {
                ExtVaule01 = iprot.ReadString();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 13:
              if (field.Type == TType.String) {
                ExtStr02 = iprot.ReadString();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 14:
              if (field.Type == TType.String) {
                ExtVaule02 = iprot.ReadString();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 15:
              if (field.Type == TType.String) {
                ExtStr03 = iprot.ReadString();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 16:
              if (field.Type == TType.String) {
                ExtVaule03 = iprot.ReadString();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 17:
              if (field.Type == TType.String) {
                ExtStr04 = iprot.ReadString();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 18:
              if (field.Type == TType.String) {
                ExtVaule04 = iprot.ReadString();
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
        TStruct struc = new TStruct("ProductListResult");
        oprot.WriteStructBegin(struc);
        TField field = new TField();
        if (__isset.ProductID) {
          field.Name = "ProductID";
          field.Type = TType.I32;
          field.ID = 1;
          oprot.WriteFieldBegin(field);
          oprot.WriteI32(ProductID);
          oprot.WriteFieldEnd();
        }
        if (ProductName != null && __isset.ProductName) {
          field.Name = "ProductName";
          field.Type = TType.String;
          field.ID = 2;
          oprot.WriteFieldBegin(field);
          oprot.WriteString(ProductName);
          oprot.WriteFieldEnd();
        }
        if (__isset.ProductType) {
          field.Name = "ProductType";
          field.Type = TType.I32;
          field.ID = 3;
          oprot.WriteFieldBegin(field);
          oprot.WriteI32(ProductType);
          oprot.WriteFieldEnd();
        }
        if (CategoryName != null && __isset.CategoryName) {
          field.Name = "CategoryName";
          field.Type = TType.String;
          field.ID = 4;
          oprot.WriteFieldBegin(field);
          oprot.WriteString(CategoryName);
          oprot.WriteFieldEnd();
        }
        if (CodeName != null && __isset.CodeName) {
          field.Name = "CodeName";
          field.Type = TType.String;
          field.ID = 5;
          oprot.WriteFieldBegin(field);
          oprot.WriteString(CodeName);
          oprot.WriteFieldEnd();
        }
        if (ProductStatusType != null && __isset.ProductStatusType) {
          field.Name = "ProductStatusType";
          field.Type = TType.String;
          field.ID = 6;
          oprot.WriteFieldBegin(field);
          oprot.WriteString(ProductStatusType);
          oprot.WriteFieldEnd();
        }
        if (FundLogo != null && __isset.FundLogo) {
          field.Name = "FundLogo";
          field.Type = TType.String;
          field.ID = 7;
          oprot.WriteFieldBegin(field);
          oprot.WriteString(FundLogo);
          oprot.WriteFieldEnd();
        }
        if (CompanyName != null && __isset.CompanyName) {
          field.Name = "CompanyName";
          field.Type = TType.String;
          field.ID = 8;
          oprot.WriteFieldBegin(field);
          oprot.WriteString(CompanyName);
          oprot.WriteFieldEnd();
        }
        if (MemberName != null && __isset.MemberName) {
          field.Name = "MemberName";
          field.Type = TType.String;
          field.ID = 9;
          oprot.WriteFieldBegin(field);
          oprot.WriteString(MemberName);
          oprot.WriteFieldEnd();
        }
        if (CreateTime != null && __isset.CreateTime) {
          field.Name = "CreateTime";
          field.Type = TType.String;
          field.ID = 10;
          oprot.WriteFieldBegin(field);
          oprot.WriteString(CreateTime);
          oprot.WriteFieldEnd();
        }
        if (ExtStr01 != null && __isset.ExtStr01) {
          field.Name = "ExtStr01";
          field.Type = TType.String;
          field.ID = 11;
          oprot.WriteFieldBegin(field);
          oprot.WriteString(ExtStr01);
          oprot.WriteFieldEnd();
        }
        if (ExtVaule01 != null && __isset.ExtVaule01) {
          field.Name = "ExtVaule01";
          field.Type = TType.String;
          field.ID = 12;
          oprot.WriteFieldBegin(field);
          oprot.WriteString(ExtVaule01);
          oprot.WriteFieldEnd();
        }
        if (ExtStr02 != null && __isset.ExtStr02) {
          field.Name = "ExtStr02";
          field.Type = TType.String;
          field.ID = 13;
          oprot.WriteFieldBegin(field);
          oprot.WriteString(ExtStr02);
          oprot.WriteFieldEnd();
        }
        if (ExtVaule02 != null && __isset.ExtVaule02) {
          field.Name = "ExtVaule02";
          field.Type = TType.String;
          field.ID = 14;
          oprot.WriteFieldBegin(field);
          oprot.WriteString(ExtVaule02);
          oprot.WriteFieldEnd();
        }
        if (ExtStr03 != null && __isset.ExtStr03) {
          field.Name = "ExtStr03";
          field.Type = TType.String;
          field.ID = 15;
          oprot.WriteFieldBegin(field);
          oprot.WriteString(ExtStr03);
          oprot.WriteFieldEnd();
        }
        if (ExtVaule03 != null && __isset.ExtVaule03) {
          field.Name = "ExtVaule03";
          field.Type = TType.String;
          field.ID = 16;
          oprot.WriteFieldBegin(field);
          oprot.WriteString(ExtVaule03);
          oprot.WriteFieldEnd();
        }
        if (ExtStr04 != null && __isset.ExtStr04) {
          field.Name = "ExtStr04";
          field.Type = TType.String;
          field.ID = 17;
          oprot.WriteFieldBegin(field);
          oprot.WriteString(ExtStr04);
          oprot.WriteFieldEnd();
        }
        if (ExtVaule04 != null && __isset.ExtVaule04) {
          field.Name = "ExtVaule04";
          field.Type = TType.String;
          field.ID = 18;
          oprot.WriteFieldBegin(field);
          oprot.WriteString(ExtVaule04);
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
      StringBuilder __sb = new StringBuilder("ProductListResult(");
      bool __first = true;
      if (__isset.ProductID) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("ProductID: ");
        __sb.Append(ProductID);
      }
      if (ProductName != null && __isset.ProductName) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("ProductName: ");
        __sb.Append(ProductName);
      }
      if (__isset.ProductType) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("ProductType: ");
        __sb.Append(ProductType);
      }
      if (CategoryName != null && __isset.CategoryName) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("CategoryName: ");
        __sb.Append(CategoryName);
      }
      if (CodeName != null && __isset.CodeName) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("CodeName: ");
        __sb.Append(CodeName);
      }
      if (ProductStatusType != null && __isset.ProductStatusType) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("ProductStatusType: ");
        __sb.Append(ProductStatusType);
      }
      if (FundLogo != null && __isset.FundLogo) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("FundLogo: ");
        __sb.Append(FundLogo);
      }
      if (CompanyName != null && __isset.CompanyName) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("CompanyName: ");
        __sb.Append(CompanyName);
      }
      if (MemberName != null && __isset.MemberName) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("MemberName: ");
        __sb.Append(MemberName);
      }
      if (CreateTime != null && __isset.CreateTime) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("CreateTime: ");
        __sb.Append(CreateTime);
      }
      if (ExtStr01 != null && __isset.ExtStr01) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("ExtStr01: ");
        __sb.Append(ExtStr01);
      }
      if (ExtVaule01 != null && __isset.ExtVaule01) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("ExtVaule01: ");
        __sb.Append(ExtVaule01);
      }
      if (ExtStr02 != null && __isset.ExtStr02) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("ExtStr02: ");
        __sb.Append(ExtStr02);
      }
      if (ExtVaule02 != null && __isset.ExtVaule02) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("ExtVaule02: ");
        __sb.Append(ExtVaule02);
      }
      if (ExtStr03 != null && __isset.ExtStr03) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("ExtStr03: ");
        __sb.Append(ExtStr03);
      }
      if (ExtVaule03 != null && __isset.ExtVaule03) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("ExtVaule03: ");
        __sb.Append(ExtVaule03);
      }
      if (ExtStr04 != null && __isset.ExtStr04) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("ExtStr04: ");
        __sb.Append(ExtStr04);
      }
      if (ExtVaule04 != null && __isset.ExtVaule04) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("ExtVaule04: ");
        __sb.Append(ExtVaule04);
      }
      __sb.Append(")");
      return __sb.ToString();
    }

  }

}