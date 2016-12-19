/**
 * Autogenerated by Thrift Compiler (0.9.1)
 *
 * DO NOT EDIT UNLESS YOU ARE SURE THAT YOU KNOW WHAT YOU ARE DOING
 *  @generated
 */
package com.kaixin001.hero.client.upload.tools.auto;

import org.apache.thrift.scheme.IScheme;
import org.apache.thrift.scheme.SchemeFactory;
import org.apache.thrift.scheme.StandardScheme;

import org.apache.thrift.scheme.TupleScheme;
import org.apache.thrift.protocol.TTupleProtocol;
import org.apache.thrift.protocol.TProtocolException;
import org.apache.thrift.EncodingUtils;
import org.apache.thrift.TException;
import org.apache.thrift.async.AsyncMethodCallback;
import org.apache.thrift.server.AbstractNonblockingServer.*;
import java.util.List;
import java.util.ArrayList;
import java.util.Map;
import java.util.HashMap;
import java.util.EnumMap;
import java.util.Set;
import java.util.HashSet;
import java.util.EnumSet;
import java.util.Collections;
import java.util.BitSet;
import java.nio.ByteBuffer;
import java.util.Arrays;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

public class Listmap implements org.apache.thrift.TBase<Listmap, Listmap._Fields>, java.io.Serializable, Cloneable, Comparable<Listmap> {
  private static final org.apache.thrift.protocol.TStruct STRUCT_DESC = new org.apache.thrift.protocol.TStruct("Listmap");

  private static final org.apache.thrift.protocol.TField TMP_LIST_FIELD_DESC = new org.apache.thrift.protocol.TField("tmpList", org.apache.thrift.protocol.TType.LIST, (short)1);

  private static final Map<Class<? extends IScheme>, SchemeFactory> schemes = new HashMap<Class<? extends IScheme>, SchemeFactory>();
  static {
    schemes.put(StandardScheme.class, new ListmapStandardSchemeFactory());
    schemes.put(TupleScheme.class, new ListmapTupleSchemeFactory());
  }

  public List<Map<Integer,Integer>> tmpList; // required

  /** The set of fields this struct contains, along with convenience methods for finding and manipulating them. */
  public enum _Fields implements org.apache.thrift.TFieldIdEnum {
    TMP_LIST((short)1, "tmpList");

    private static final Map<String, _Fields> byName = new HashMap<String, _Fields>();

    static {
      for (_Fields field : EnumSet.allOf(_Fields.class)) {
        byName.put(field.getFieldName(), field);
      }
    }

    /**
     * Find the _Fields constant that matches fieldId, or null if its not found.
     */
    public static _Fields findByThriftId(int fieldId) {
      switch(fieldId) {
        case 1: // TMP_LIST
          return TMP_LIST;
        default:
          return null;
      }
    }

    /**
     * Find the _Fields constant that matches fieldId, throwing an exception
     * if it is not found.
     */
    public static _Fields findByThriftIdOrThrow(int fieldId) {
      _Fields fields = findByThriftId(fieldId);
      if (fields == null) throw new IllegalArgumentException("Field " + fieldId + " doesn't exist!");
      return fields;
    }

    /**
     * Find the _Fields constant that matches name, or null if its not found.
     */
    public static _Fields findByName(String name) {
      return byName.get(name);
    }

    private final short _thriftId;
    private final String _fieldName;

    _Fields(short thriftId, String fieldName) {
      _thriftId = thriftId;
      _fieldName = fieldName;
    }

    public short getThriftFieldId() {
      return _thriftId;
    }

    public String getFieldName() {
      return _fieldName;
    }
  }

  // isset id assignments
  public static final Map<_Fields, org.apache.thrift.meta_data.FieldMetaData> metaDataMap;
  static {
    Map<_Fields, org.apache.thrift.meta_data.FieldMetaData> tmpMap = new EnumMap<_Fields, org.apache.thrift.meta_data.FieldMetaData>(_Fields.class);
    tmpMap.put(_Fields.TMP_LIST, new org.apache.thrift.meta_data.FieldMetaData("tmpList", org.apache.thrift.TFieldRequirementType.DEFAULT, 
        new org.apache.thrift.meta_data.ListMetaData(org.apache.thrift.protocol.TType.LIST, 
            new org.apache.thrift.meta_data.MapMetaData(org.apache.thrift.protocol.TType.MAP, 
                new org.apache.thrift.meta_data.FieldValueMetaData(org.apache.thrift.protocol.TType.I32), 
                new org.apache.thrift.meta_data.FieldValueMetaData(org.apache.thrift.protocol.TType.I32)))));
    metaDataMap = Collections.unmodifiableMap(tmpMap);
    org.apache.thrift.meta_data.FieldMetaData.addStructMetaDataMap(Listmap.class, metaDataMap);
  }

  public Listmap() {
  }

  public Listmap(
    List<Map<Integer,Integer>> tmpList)
  {
    this();
    this.tmpList = tmpList;
  }

  /**
   * Performs a deep copy on <i>other</i>.
   */
  public Listmap(Listmap other) {
    if (other.isSetTmpList()) {
      List<Map<Integer,Integer>> __this__tmpList = new ArrayList<Map<Integer,Integer>>(other.tmpList.size());
      for (Map<Integer,Integer> other_element : other.tmpList) {
        Map<Integer,Integer> __this__tmpList_copy = new HashMap<Integer,Integer>(other_element);
        __this__tmpList.add(__this__tmpList_copy);
      }
      this.tmpList = __this__tmpList;
    }
  }

  public Listmap deepCopy() {
    return new Listmap(this);
  }

  @Override
  public void clear() {
    this.tmpList = null;
  }

  public int getTmpListSize() {
    return (this.tmpList == null) ? 0 : this.tmpList.size();
  }

  public java.util.Iterator<Map<Integer,Integer>> getTmpListIterator() {
    return (this.tmpList == null) ? null : this.tmpList.iterator();
  }

  public void addToTmpList(Map<Integer,Integer> elem) {
    if (this.tmpList == null) {
      this.tmpList = new ArrayList<Map<Integer,Integer>>();
    }
    this.tmpList.add(elem);
  }

  public List<Map<Integer,Integer>> getTmpList() {
    return this.tmpList;
  }

  public Listmap setTmpList(List<Map<Integer,Integer>> tmpList) {
    this.tmpList = tmpList;
    return this;
  }

  public void unsetTmpList() {
    this.tmpList = null;
  }

  /** Returns true if field tmpList is set (has been assigned a value) and false otherwise */
  public boolean isSetTmpList() {
    return this.tmpList != null;
  }

  public void setTmpListIsSet(boolean value) {
    if (!value) {
      this.tmpList = null;
    }
  }

  public void setFieldValue(_Fields field, Object value) {
    switch (field) {
    case TMP_LIST:
      if (value == null) {
        unsetTmpList();
      } else {
        setTmpList((List<Map<Integer,Integer>>)value);
      }
      break;

    }
  }

  public Object getFieldValue(_Fields field) {
    switch (field) {
    case TMP_LIST:
      return getTmpList();

    }
    throw new IllegalStateException();
  }

  /** Returns true if field corresponding to fieldID is set (has been assigned a value) and false otherwise */
  public boolean isSet(_Fields field) {
    if (field == null) {
      throw new IllegalArgumentException();
    }

    switch (field) {
    case TMP_LIST:
      return isSetTmpList();
    }
    throw new IllegalStateException();
  }

  @Override
  public boolean equals(Object that) {
    if (that == null)
      return false;
    if (that instanceof Listmap)
      return this.equals((Listmap)that);
    return false;
  }

  public boolean equals(Listmap that) {
    if (that == null)
      return false;

    boolean this_present_tmpList = true && this.isSetTmpList();
    boolean that_present_tmpList = true && that.isSetTmpList();
    if (this_present_tmpList || that_present_tmpList) {
      if (!(this_present_tmpList && that_present_tmpList))
        return false;
      if (!this.tmpList.equals(that.tmpList))
        return false;
    }

    return true;
  }

  @Override
  public int hashCode() {
    return 0;
  }

  @Override
  public int compareTo(Listmap other) {
    if (!getClass().equals(other.getClass())) {
      return getClass().getName().compareTo(other.getClass().getName());
    }

    int lastComparison = 0;

    lastComparison = Boolean.valueOf(isSetTmpList()).compareTo(other.isSetTmpList());
    if (lastComparison != 0) {
      return lastComparison;
    }
    if (isSetTmpList()) {
      lastComparison = org.apache.thrift.TBaseHelper.compareTo(this.tmpList, other.tmpList);
      if (lastComparison != 0) {
        return lastComparison;
      }
    }
    return 0;
  }

  public _Fields fieldForId(int fieldId) {
    return _Fields.findByThriftId(fieldId);
  }

  public void read(org.apache.thrift.protocol.TProtocol iprot) throws org.apache.thrift.TException {
    schemes.get(iprot.getScheme()).getScheme().read(iprot, this);
  }

  public void write(org.apache.thrift.protocol.TProtocol oprot) throws org.apache.thrift.TException {
    schemes.get(oprot.getScheme()).getScheme().write(oprot, this);
  }

  @Override
  public String toString() {
    StringBuilder sb = new StringBuilder("Listmap(");
    boolean first = true;

    sb.append("tmpList:");
    if (this.tmpList == null) {
      sb.append("null");
    } else {
      sb.append(this.tmpList);
    }
    first = false;
    sb.append(")");
    return sb.toString();
  }

  public void validate() throws org.apache.thrift.TException {
    // check for required fields
    // check for sub-struct validity
  }

  private void writeObject(java.io.ObjectOutputStream out) throws java.io.IOException {
    try {
      write(new org.apache.thrift.protocol.TCompactProtocol(new org.apache.thrift.transport.TIOStreamTransport(out)));
    } catch (org.apache.thrift.TException te) {
      throw new java.io.IOException(te);
    }
  }

  private void readObject(java.io.ObjectInputStream in) throws java.io.IOException, ClassNotFoundException {
    try {
      read(new org.apache.thrift.protocol.TCompactProtocol(new org.apache.thrift.transport.TIOStreamTransport(in)));
    } catch (org.apache.thrift.TException te) {
      throw new java.io.IOException(te);
    }
  }

  private static class ListmapStandardSchemeFactory implements SchemeFactory {
    public ListmapStandardScheme getScheme() {
      return new ListmapStandardScheme();
    }
  }

  private static class ListmapStandardScheme extends StandardScheme<Listmap> {

    public void read(org.apache.thrift.protocol.TProtocol iprot, Listmap struct) throws org.apache.thrift.TException {
      org.apache.thrift.protocol.TField schemeField;
      iprot.readStructBegin();
      while (true)
      {
        schemeField = iprot.readFieldBegin();
        if (schemeField.type == org.apache.thrift.protocol.TType.STOP) { 
          break;
        }
        switch (schemeField.id) {
          case 1: // TMP_LIST
            if (schemeField.type == org.apache.thrift.protocol.TType.LIST) {
              {
                org.apache.thrift.protocol.TList _list52 = iprot.readListBegin();
                struct.tmpList = new ArrayList<Map<Integer,Integer>>(_list52.size);
                for (int _i53 = 0; _i53 < _list52.size; ++_i53)
                {
                  Map<Integer,Integer> _elem54;
                  {
                    org.apache.thrift.protocol.TMap _map55 = iprot.readMapBegin();
                    _elem54 = new HashMap<Integer,Integer>(2*_map55.size);
                    for (int _i56 = 0; _i56 < _map55.size; ++_i56)
                    {
                      int _key57;
                      int _val58;
                      _key57 = iprot.readI32();
                      _val58 = iprot.readI32();
                      _elem54.put(_key57, _val58);
                    }
                    iprot.readMapEnd();
                  }
                  struct.tmpList.add(_elem54);
                }
                iprot.readListEnd();
              }
              struct.setTmpListIsSet(true);
            } else { 
              org.apache.thrift.protocol.TProtocolUtil.skip(iprot, schemeField.type);
            }
            break;
          default:
            org.apache.thrift.protocol.TProtocolUtil.skip(iprot, schemeField.type);
        }
        iprot.readFieldEnd();
      }
      iprot.readStructEnd();

      // check for required fields of primitive type, which can't be checked in the validate method
      struct.validate();
    }

    public void write(org.apache.thrift.protocol.TProtocol oprot, Listmap struct) throws org.apache.thrift.TException {
      struct.validate();

      oprot.writeStructBegin(STRUCT_DESC);
      if (struct.tmpList != null) {
        oprot.writeFieldBegin(TMP_LIST_FIELD_DESC);
        {
          oprot.writeListBegin(new org.apache.thrift.protocol.TList(org.apache.thrift.protocol.TType.MAP, struct.tmpList.size()));
          for (Map<Integer,Integer> _iter59 : struct.tmpList)
          {
            {
              oprot.writeMapBegin(new org.apache.thrift.protocol.TMap(org.apache.thrift.protocol.TType.I32, org.apache.thrift.protocol.TType.I32, _iter59.size()));
              for (Map.Entry<Integer, Integer> _iter60 : _iter59.entrySet())
              {
                oprot.writeI32(_iter60.getKey());
                oprot.writeI32(_iter60.getValue());
              }
              oprot.writeMapEnd();
            }
          }
          oprot.writeListEnd();
        }
        oprot.writeFieldEnd();
      }
      oprot.writeFieldStop();
      oprot.writeStructEnd();
    }

  }

  private static class ListmapTupleSchemeFactory implements SchemeFactory {
    public ListmapTupleScheme getScheme() {
      return new ListmapTupleScheme();
    }
  }

  private static class ListmapTupleScheme extends TupleScheme<Listmap> {

    @Override
    public void write(org.apache.thrift.protocol.TProtocol prot, Listmap struct) throws org.apache.thrift.TException {
      TTupleProtocol oprot = (TTupleProtocol) prot;
      BitSet optionals = new BitSet();
      if (struct.isSetTmpList()) {
        optionals.set(0);
      }
      oprot.writeBitSet(optionals, 1);
      if (struct.isSetTmpList()) {
        {
          oprot.writeI32(struct.tmpList.size());
          for (Map<Integer,Integer> _iter61 : struct.tmpList)
          {
            {
              oprot.writeI32(_iter61.size());
              for (Map.Entry<Integer, Integer> _iter62 : _iter61.entrySet())
              {
                oprot.writeI32(_iter62.getKey());
                oprot.writeI32(_iter62.getValue());
              }
            }
          }
        }
      }
    }

    @Override
    public void read(org.apache.thrift.protocol.TProtocol prot, Listmap struct) throws org.apache.thrift.TException {
      TTupleProtocol iprot = (TTupleProtocol) prot;
      BitSet incoming = iprot.readBitSet(1);
      if (incoming.get(0)) {
        {
          org.apache.thrift.protocol.TList _list63 = new org.apache.thrift.protocol.TList(org.apache.thrift.protocol.TType.MAP, iprot.readI32());
          struct.tmpList = new ArrayList<Map<Integer,Integer>>(_list63.size);
          for (int _i64 = 0; _i64 < _list63.size; ++_i64)
          {
            Map<Integer,Integer> _elem65;
            {
              org.apache.thrift.protocol.TMap _map66 = new org.apache.thrift.protocol.TMap(org.apache.thrift.protocol.TType.I32, org.apache.thrift.protocol.TType.I32, iprot.readI32());
              _elem65 = new HashMap<Integer,Integer>(2*_map66.size);
              for (int _i67 = 0; _i67 < _map66.size; ++_i67)
              {
                int _key68;
                int _val69;
                _key68 = iprot.readI32();
                _val69 = iprot.readI32();
                _elem65.put(_key68, _val69);
              }
            }
            struct.tmpList.add(_elem65);
          }
        }
        struct.setTmpListIsSet(true);
      }
    }
  }

}

