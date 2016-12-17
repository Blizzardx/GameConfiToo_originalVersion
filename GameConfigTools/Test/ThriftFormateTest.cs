using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Message;
using Config;

namespace GameConfigTools.Test
{
    class ThriftFormateTest
    {
        public void Main1()
        {
            int testValue = int.MinValue;
            ThriftPacker tmp = new ThriftPacker();
            ThriftPacker.TField tmpFile = new ThriftPacker.TField();
            tmpFile.ID = 1;
            tmpFile.Name = "id";
            tmpFile.Type = ThriftPacker.TType.I32;

            tmp.WriteStructBegin();
            tmp.WriteFieldBegin(tmpFile);
            tmp.WriteI32(testValue);
            tmp.WriteFieldEnd();
            tmp.WriteFieldStop();
            tmp.WriteStructEnd();

            TestInt testInt = new TestInt();
            //testInt.Id = 100;
            //var bytes = ThriftSerialize.Serialize(testInt);
            ThriftSerialize.DeSerialize(testInt, tmp.GetBuffer());
            int a = testInt.Id;
        }

        public void Test1()
        {
            
        }
        public void Main()
        {
            TestInt testInt = new TestInt();
            testInt.Id = 3;
            var bytes = ThriftSerialize.Serialize(testInt);
            File.WriteAllBytes("testInt.bytes", bytes);
            byte[] array = new byte[]{21,};
            TestString testString = new TestString();
            testString.Id = "0";
            bytes = ThriftSerialize.Serialize(testString);
            File.WriteAllBytes("testString.bytes", bytes);

            Testfloat testFloat = new Testfloat();
            testFloat.Id = 0.0f;
            bytes = ThriftSerialize.Serialize(testFloat);
            File.WriteAllBytes("testFloat.bytes", bytes);

            TestBool testBool = new TestBool();
            testBool.Id = true;
            bytes = ThriftSerialize.Serialize(testBool);
            File.WriteAllBytes("testBool.bytes", bytes);

            TestByte testByte = new TestByte();
            testByte.Id = 0;
            bytes = ThriftSerialize.Serialize(testByte);
            File.WriteAllBytes("testByte.bytes", bytes);

            TesetCompose testCompose = new TesetCompose();
            testCompose.Id = 0;
            testCompose.StringId = "0";
            testCompose.BoolId = true;
            testCompose.ByteId = 0;
            testCompose.DoubleId = 0.0f;
            bytes = ThriftSerialize.Serialize(testCompose);
            File.WriteAllBytes("testCompose.bytes", bytes);

            TestCompose1 testCompose1 = new TestCompose1();
            testCompose1.TmpList = new List<int>(){1,2,3,4,5};
            bytes = ThriftSerialize.Serialize(testCompose1);
            File.WriteAllBytes("testCompose1.bytes", bytes);

            TestCompose2 testCompose2 = new TestCompose2();
            testCompose2.TmpMap = new Dictionary<int, int>();
            testCompose2.TmpMap.Add(0, 0);
            testCompose2.TmpMap.Add(1, 1);
            testCompose2.TmpMap.Add(2, 2);
            testCompose2.TmpMap.Add(3, 3);
            testCompose2.TmpMap.Add(4, 4);
            testCompose2.TmpMap.Add(5, 5);
            bytes = ThriftSerialize.Serialize(testCompose2);
            File.WriteAllBytes("testCompose2.bytes", bytes);

            TestCompose3 testCompose3 = new TestCompose3();
            testCompose3.TmpList = new List<TestCompose1>() { testCompose1, testCompose1, testCompose1 };
            bytes = ThriftSerialize.Serialize(testCompose3);
            File.WriteAllBytes("testCompose3.bytes", bytes);

            TestCompose4 testCompose4 = new TestCompose4();
            testCompose4.TmpMap = new Dictionary<int, TestCompose3>();
            testCompose4.TmpMap.Add(0, testCompose3);
            testCompose4.TmpMap.Add(1, testCompose3);
            testCompose4.TmpMap.Add(2, testCompose3);

            bytes = ThriftSerialize.Serialize(testCompose4);
            File.WriteAllBytes("testCompose4.bytes", bytes);
        }
    }
}