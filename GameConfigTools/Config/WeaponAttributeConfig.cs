/**
 * Autogenerated by Thrift Compiler (0.9.1)
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

namespace Config
{

  #if !SILVERLIGHT
  [Serializable]
  #endif
  public partial class WeaponAttributeConfig : TBase
  {
    private int _weaponId;
    private int _star;
    private int _normalSkill;
    private int _upStarConsumeId;
    private List<int> _passiveSkillList;
    private Dictionary<int, int> _attrMap;
    private string _bulletTexture;

    public int WeaponId
    {
      get
      {
        return _weaponId;
      }
      set
      {
        __isset.weaponId = true;
        this._weaponId = value;
      }
    }

    public int Star
    {
      get
      {
        return _star;
      }
      set
      {
        __isset.star = true;
        this._star = value;
      }
    }

    public int NormalSkill
    {
      get
      {
        return _normalSkill;
      }
      set
      {
        __isset.normalSkill = true;
        this._normalSkill = value;
      }
    }

    public int UpStarConsumeId
    {
      get
      {
        return _upStarConsumeId;
      }
      set
      {
        __isset.upStarConsumeId = true;
        this._upStarConsumeId = value;
      }
    }

    public List<int> PassiveSkillList
    {
      get
      {
        return _passiveSkillList;
      }
      set
      {
        __isset.passiveSkillList = true;
        this._passiveSkillList = value;
      }
    }

    public Dictionary<int, int> AttrMap
    {
      get
      {
        return _attrMap;
      }
      set
      {
        __isset.attrMap = true;
        this._attrMap = value;
      }
    }

    public string BulletTexture
    {
      get
      {
        return _bulletTexture;
      }
      set
      {
        __isset.bulletTexture = true;
        this._bulletTexture = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool weaponId;
      public bool star;
      public bool normalSkill;
      public bool upStarConsumeId;
      public bool passiveSkillList;
      public bool attrMap;
      public bool bulletTexture;
    }

    public WeaponAttributeConfig() {
    }

    public void Read (TProtocol iprot)
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
          case 10:
            if (field.Type == TType.I32) {
              WeaponId = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 20:
            if (field.Type == TType.I32) {
              Star = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 30:
            if (field.Type == TType.I32) {
              NormalSkill = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 40:
            if (field.Type == TType.I32) {
              UpStarConsumeId = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 60:
            if (field.Type == TType.List) {
              {
                PassiveSkillList = new List<int>();
                TList _list242 = iprot.ReadListBegin();
                for( int _i243 = 0; _i243 < _list242.Count; ++_i243)
                {
                  int _elem244 = 0;
                  _elem244 = iprot.ReadI32();
                  PassiveSkillList.Add(_elem244);
                }
                iprot.ReadListEnd();
              }
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 70:
            if (field.Type == TType.Map) {
              {
                AttrMap = new Dictionary<int, int>();
                TMap _map245 = iprot.ReadMapBegin();
                for( int _i246 = 0; _i246 < _map245.Count; ++_i246)
                {
                  int _key247;
                  int _val248;
                  _key247 = iprot.ReadI32();
                  _val248 = iprot.ReadI32();
                  AttrMap[_key247] = _val248;
                }
                iprot.ReadMapEnd();
              }
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 80:
            if (field.Type == TType.String) {
              BulletTexture = iprot.ReadString();
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

    public void Write(TProtocol oprot) {
      TStruct struc = new TStruct("WeaponAttributeConfig");
      oprot.WriteStructBegin(struc);
      TField field = new TField();
      if (__isset.weaponId) {
        field.Name = "weaponId";
        field.Type = TType.I32;
        field.ID = 10;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(WeaponId);
        oprot.WriteFieldEnd();
      }
      if (__isset.star) {
        field.Name = "star";
        field.Type = TType.I32;
        field.ID = 20;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(Star);
        oprot.WriteFieldEnd();
      }
      if (__isset.normalSkill) {
        field.Name = "normalSkill";
        field.Type = TType.I32;
        field.ID = 30;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(NormalSkill);
        oprot.WriteFieldEnd();
      }
      if (__isset.upStarConsumeId) {
        field.Name = "upStarConsumeId";
        field.Type = TType.I32;
        field.ID = 40;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(UpStarConsumeId);
        oprot.WriteFieldEnd();
      }
      if (PassiveSkillList != null && __isset.passiveSkillList) {
        field.Name = "passiveSkillList";
        field.Type = TType.List;
        field.ID = 60;
        oprot.WriteFieldBegin(field);
        {
          oprot.WriteListBegin(new TList(TType.I32, PassiveSkillList.Count));
          foreach (int _iter249 in PassiveSkillList)
          {
            oprot.WriteI32(_iter249);
          }
          oprot.WriteListEnd();
        }
        oprot.WriteFieldEnd();
      }
      if (AttrMap != null && __isset.attrMap) {
        field.Name = "attrMap";
        field.Type = TType.Map;
        field.ID = 70;
        oprot.WriteFieldBegin(field);
        {
          oprot.WriteMapBegin(new TMap(TType.I32, TType.I32, AttrMap.Count));
          foreach (int _iter250 in AttrMap.Keys)
          {
            oprot.WriteI32(_iter250);
            oprot.WriteI32(AttrMap[_iter250]);
          }
          oprot.WriteMapEnd();
        }
        oprot.WriteFieldEnd();
      }
      if (BulletTexture != null && __isset.bulletTexture) {
        field.Name = "bulletTexture";
        field.Type = TType.String;
        field.ID = 80;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(BulletTexture);
        oprot.WriteFieldEnd();
      }
      oprot.WriteFieldStop();
      oprot.WriteStructEnd();
    }

    public override string ToString() {
      StringBuilder sb = new StringBuilder("WeaponAttributeConfig(");
      sb.Append("WeaponId: ");
      sb.Append(WeaponId);
      sb.Append(",Star: ");
      sb.Append(Star);
      sb.Append(",NormalSkill: ");
      sb.Append(NormalSkill);
      sb.Append(",UpStarConsumeId: ");
      sb.Append(UpStarConsumeId);
      sb.Append(",PassiveSkillList: ");
      sb.Append(PassiveSkillList);
      sb.Append(",AttrMap: ");
      sb.Append(AttrMap);
      sb.Append(",BulletTexture: ");
      sb.Append(BulletTexture);
      sb.Append(")");
      return sb.ToString();
    }

  }

}
