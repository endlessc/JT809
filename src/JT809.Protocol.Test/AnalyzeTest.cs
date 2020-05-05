﻿using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using JT809.Protocol;
using JT809.Protocol.Extensions;
using System.Threading.Tasks;
using System.Diagnostics;
using JT809.Protocol.Enums;
using JT809.Protocol.Internal;
using JT809.Protocol.MessageBody;
using JT809.Protocol.SubMessageBody;

namespace JT809.Protocol.Test
{
    public  class AnalyzeTest
    {
        private JT809Serializer JT809_2019_Serializer = new JT809Serializer(new DefaultGlobalConfig() { Version = JT809Version.JTT2019 });
        private JT809Serializer JT809Serializer = new JT809Serializer();
        [Fact]
        public void Test1()
        {
            string hex = "01 33 EF B8 32 30 31 38 30 39 32 30 31 32 37 2E 30 2E 30 2E 31 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 03 29";
            var json = JT809Serializer.Analyze<JT809_0x1001>(hex.ToHexBytes());
            hex = "0133EFB8323031383039323002A7DD233132372E302E302E3100000000000000000000000000000000000000000000000329";
            json = JT809_2019_Serializer.Analyze<JT809_0x1001>(hex.ToHexBytes());
            //ref demo1-test3
            hex = "5B000000920000068294000133EFB8010000000000270FD4C1413132333435000000000000000000000000000294010000005C010002000000005A01AC3F40123FFAA1000000005A01AC4D5001736D616C6C636869000000000000000031323334353637383930310000000000000000003132333435364071712E636F6D000000000000000000000000000000000000007AEA5D";
            json = JT809Serializer.Analyze(hex.ToHexBytes());
            // ref 0x1201-test3
            hex = "5B000000AC000006821200013415F4010000000000270F000000005E02A507B8D4C1413132333435000000000000000000000000000112010000006E31313131313131313131003131313131313131313100313131313131313100000000000000000000000000000000000000000000313233343536373839000000000000313131313141410000000000000000000000000000000000000000000000323232323232323232323232006D7A5D";
            json = JT809_2019_Serializer.Analyze(hex.ToHexBytes());

            hex = "00 00 00 D4 B8";
            json = JT809Serializer.Analyze<JT809_0x1002>(hex.ToHexBytes());

            hex = "0133EFB83230313830393230";
            json = JT809Serializer.Analyze<JT809_0x1003>(hex.ToHexBytes());

            hex = "00";
            json = JT809Serializer.Analyze<JT809_0x1007>(hex.ToHexBytes());

            hex = "00";
            json = JT809Serializer.Analyze<JT809_0x1008>(hex.ToHexBytes());

            hex = "D4C1413132333435000000000000000000000000000112010000003D31313131313131313131003131313131313131313100313131313131313100000000000000000000000031313131314141323232323232323232323232";
            json = JT809Serializer.Analyze<JT809_0x1200>(hex.ToHexBytes());

            hex = "D4C1413132333435000000000000000000000000000112010000006E3131313131313131313100313131313131313131310031313131313131310000000000000000000000000000000000000000000031323334353637383900000000000031313131314141000000000000000000000000000000000000000000000032323232323232323232323200";
            json = JT809_2019_Serializer.Analyze<JT809_0x1200>(hex.ToHexBytes());

            hex = "13010000001B01313131000000000000000000000004D200000006323268613232";
            json = JT809Serializer.Analyze<JT809_0x1300>(hex.ToHexBytes());

            hex = "13010000004901736D616C6C636869000000000000000031323334353637383930310000000000000000003131310000000000000000000000000000000000006F0000006300000006323268613232";
            json = JT809_2019_Serializer.Analyze<JT809_0x1300>(hex.ToHexBytes());

            hex = "D4C14131323334350000000000000000000000000001160100000006CAB2C3B4B9ED";
            json = JT809Serializer.Analyze<JT809_0x1600>(hex.ToHexBytes());

            hex = "D4C1413132333435000000000000000000000000000116010000000C000100000002CAB2C3B4B9ED";
            json = JT809_2019_Serializer.Analyze<JT809_0x1600>(hex.ToHexBytes());

            hex = "0000B18E";
            json = JT809Serializer.Analyze<JT809_0x9001>(hex.ToHexBytes());

            hex = "00";
            json = JT809Serializer.Analyze<JT809_0x9002>(hex.ToHexBytes());

            hex = "00 00 B1 8E";
            json = JT809Serializer.Analyze<JT809_0x9003>(hex.ToHexBytes());

            hex = "00";
            json = JT809Serializer.Analyze<JT809_0x9007>(hex.ToHexBytes());

            hex = "01";
            json = JT809Serializer.Analyze<JT809_0x9008>(hex.ToHexBytes());

            hex = "00 00 27 10 00 00 00 00 5B A4 99 86 00 00 00 00 5B A4 DF D6";
            json = JT809Serializer.Analyze<JT809_0x9101>(hex.ToHexBytes());

            //子类型
            hex = "31313131313131313131003131313131313131313100313131313131313100000000000000000000000031313131314141323232323232323232323232";
            json = JT809Serializer.Analyze<JT809_0x1200_0x1201>(hex.ToHexBytes());

            hex = "3131313131313131313100313131313131313131310031313131313131310000000000000000000000000000000000000000000031323334353637383900000000000031313131314141000000000000000000000000000000000000000000000032323232323232323232323200";
            json = JT809_2019_Serializer.Analyze<JT809_0x1200_0x1201>(hex.ToHexBytes());

            hex = "00130707DC0F0F0F07EF4D80017018400032003300000096002D002D0000000300000101";
            json = JT809Serializer.Analyze<JT809_0x1200_0x1202>(hex.ToHexBytes());

            hex = "0100000000313131313131313131313100000001323232323232323232323200000002333333333333333333333300000003";
            json = JT809_2019_Serializer.Analyze<JT809_0x1200_0x1202>(hex.ToHexBytes());

            hex = "0300130707DC0F0F0F07EF4D80017018400032003300000096002D002D000000030000010100130707DC10101007EF4D80017018400032003300000096002D002D000000030000010100130707DC11111107EF4D80017018400032003300000096002D002D0000000300000101";
            json = JT809Serializer.Analyze<JT809_0x1200_0x1203>(hex.ToHexBytes());

            hex = "0201000000003131313131313131313131000000013232323232323232323232000000023333333333333333333333000000030100000000313131313131313131313100000001323232323232323232323200000002333333333333333333333300000003";
            json = JT809_2019_Serializer.Analyze<JT809_0x1200_0x1203>(hex.ToHexBytes());

            hex = "000000005BA880B6000000005BA9016B";
            json = JT809Serializer.Analyze<JT809_0x1200_0x1207>(hex.ToHexBytes());

            hex = "000000005BA880B6000000005BA9016B";
            json = JT809Serializer.Analyze<JT809_0x1200_0x1209>(hex.ToHexBytes());

            hex = "736D616C6C63686900000000000000003132333435363738393132333435363738390000616263646566313233343536373839000000000000000000000000000000000000000000000000007777773132333435363738390000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000";
            json = JT809Serializer.Analyze<JT809_0x1200_0x120A>(hex.ToHexBytes());

            hex = "000200000001736D616C6C63686900000000000000003132333435363738393132333435363738390000616263646566313233343536373839000000000000000000000000000000000000000000000000007777773132333435363738390000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000005EA1A49E";
            json = JT809_2019_Serializer.Analyze<JT809_0x1200_0x120A>(hex.ToHexBytes());

            hex = "0000000C617364313233343536617364";
            json = JT809Serializer.Analyze<JT809_0x1200_0x120B>(hex.ToHexBytes());

            hex = "0002000000010000000C617364313233343536617364";
            json = JT809_2019_Serializer.Analyze<JT809_0x1200_0x120B>(hex.ToHexBytes());

            hex = "736D616C6C6368690000000000000000313233343536373839303132330000000000000033323130393837363534333231000000000000000000000000000000000000000000000000000000676F760000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000";
            json = JT809Serializer.Analyze<JT809_0x1200_0x120C>(hex.ToHexBytes());

            hex = "736D616C6C6368690000000000000000313233343536373839303132330000000000000033323130393837363534333231000000000000000000000000000000000000000000000000000000676F760000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000005EA19D4F";
            json = JT809_2019_Serializer.Analyze<JT809_0x1200_0x120C>(hex.ToHexBytes());

            hex = "0000000C617364313233343536617364";
            json = JT809Serializer.Analyze<JT809_0x1200_0x120D>(hex.ToHexBytes());

            hex = "01313131000000000000000000000004D200000006323268613232";
            json = JT809Serializer.Analyze<JT809_0x1300_0x1301>(hex.ToHexBytes());

            hex = "01736D616C6C636869000000000000000031323334353637383930310000000000000000003131310000000000000000000000000000000000006F0000006300000006323268613232";
            json = JT809_2019_Serializer.Analyze<JT809_0x1300_0x1301>(hex.ToHexBytes());

            hex = "000004D2";
            json = JT809Serializer.Analyze<JT809_0x1300_0x1302>(hex.ToHexBytes());

            hex = "00990000000B";
            json = JT809_2019_Serializer.Analyze<JT809_0x1300_0x1302>(hex.ToHexBytes());

            hex = "000026AA00";
            json = JT809Serializer.Analyze<JT809_0x1400_0x1401>(hex.ToHexBytes());

            hex = "01000B000000005BAA5B8000000D100000000A67666466343534353533";
            json = JT809Serializer.Analyze<JT809_0x1400_0x1402>(hex.ToHexBytes());

            hex = "3132333435363738393030000B000000005EA06A00000000005EA06A00000000005EA1BB80D4C141313131313100000000000000000000000000013132333435363738393030000000000000000A67666466343534353533";
            json = JT809_2019_Serializer.Analyze<JT809_0x1400_0x1402>(hex.ToHexBytes());

            hex = "00000D1003";
            json = JT809Serializer.Analyze<JT809_0x1400_0x1403>(hex.ToHexBytes());

            hex = "00000000000002DFDC1C34000B000000005EA06A00000000005EA06A00000000005EA1BB80D4C1413131313131000000000000000000000000000100000000000002DFDC1C34000000370000000A67666466343534353533";
            json = JT809_2019_Serializer.Analyze<JT809_0x1400_0x1403>(hex.ToHexBytes());

            hex = "00";
            json = JT809Serializer.Analyze<JT809_0x1500_0x1501>(hex.ToHexBytes());

            hex = "0100130707DC0F0F0F07EF4D80017018400035002D000004D2002D002D00000001000000017B000000000101";
            json = JT809Serializer.Analyze<JT809_0x1500_0x1502>(hex.ToHexBytes());

            hex = "0000270F00";
            json = JT809Serializer.Analyze<JT809_0x1500_0x1503>(hex.ToHexBytes());

            hex = "00630000000B00";
            json = JT809_2019_Serializer.Analyze<JT809_0x1500_0x1503>(hex.ToHexBytes());

            hex = "0700000006313233343536";
            json = JT809Serializer.Analyze<JT809_0x1500_0x1504>(hex.ToHexBytes());

            hex = "000C000000010700000006313233343536";
            json = JT809_2019_Serializer.Analyze<JT809_0x1500_0x1504>(hex.ToHexBytes());

            hex = "01";
            json = JT809Serializer.Analyze<JT809_0x1500_0x1505>(hex.ToHexBytes());

            hex = "00050000000101";
            json = JT809_2019_Serializer.Analyze<JT809_0x1500_0x1505>(hex.ToHexBytes());

            hex = "736D616C6C636869";
            json = JT809Serializer.Analyze<JT809_0x1600_0x1601>(hex.ToHexBytes());

            hex = "000100000002736D616C6C636869";
            json = JT809_2019_Serializer.Analyze<JT809_0x1600_0x1601>(hex.ToHexBytes());

            hex = "B3B5C1BED0C5CFA2";
            json = JT809Serializer.Analyze<JT809_0x9200_0x9204>(hex.ToHexBytes());

            hex = "02";
            json = JT809Serializer.Analyze<JT809_0x9200_0x9205>(hex.ToHexBytes());

            hex = "02";
            json = JT809Serializer.Analyze<JT809_0x9200_0x9206>(hex.ToHexBytes());

            hex = "00";
            json = JT809Serializer.Analyze<JT809_0x9200_0x9207>(hex.ToHexBytes());

            hex = "00010000000200";
            json = JT809_2019_Serializer.Analyze<JT809_0x9200_0x9207>(hex.ToHexBytes());

            hex = "02";
            json = JT809Serializer.Analyze<JT809_0x9200_0x9208>(hex.ToHexBytes());

            hex = "00010000000202";
            json = JT809_2019_Serializer.Analyze<JT809_0x9200_0x9208>(hex.ToHexBytes());

            hex = "00";
            json = JT809Serializer.Analyze<JT809_0x9200_0x9209>(hex.ToHexBytes());

            hex = "00160000002100";
            json = JT809_2019_Serializer.Analyze<JT809_0x9200_0x9209>(hex.ToHexBytes());

            hex = "02736D616C6C6368690000000000000D10000000057265706C79";
            json = JT809Serializer.Analyze<JT809_0x9300_0x9301>(hex.ToHexBytes());

            hex = "00616664617366330000000000000004D200000014CFC2BCB6C6BDCCA8CBF9CAF4B5A5D2BBC6BDCCA8";
            json = JT809Serializer.Analyze<JT809_0x9300_0x9302>(hex.ToHexBytes());

            hex = "010002000000005BAC3F40123FFAA1000000005BAC4D5001736D616C6C636869000000000000000031323334353637383930310000000000000000003132333435364071712E636F6D00000000000000000000000000000000000000";
            json = JT809Serializer.Analyze<JT809_0x9400_0x9401>(hex.ToHexBytes());

            hex = "01000A000000005BE792C000000004BDD9BEAF";
            json = JT809Serializer.Analyze<JT809_0x9400_0x9402>(hex.ToHexBytes());

            hex = "00000000000002DFDC1C35000A000000005EA56104000000005EA56104000000005EA56F14D4C1413132333435000000000000000000000000000100000000000002DFDC1C350000001600000004BDD9BEAF";
            json = JT809_2019_Serializer.Analyze<JT809_0x9400_0x9402>(hex.ToHexBytes());

            hex = "010002000000005BE792C00000000CC6A3C0CDBCDDCABBB1A8BEAF";
            json = JT809Serializer.Analyze<JT809_0x9400_0x9403>(hex.ToHexBytes());

            hex = "00000000000002DFDC1C350002000000005EA56140000000005EA56140000000005EA56F50D4C1413536343700000000000000000000000000000200000000000002DFDC1C35000000000000000CC6A3C0CDBCDDCABBB1A8BEAF";
            json = JT809_2019_Serializer.Analyze<JT809_0x9400_0x9403>(hex.ToHexBytes());

            hex = "3132333435363738390000000000000000000000";
            json = JT809Serializer.Analyze<JT809_0x9500_0x9501>(hex.ToHexBytes());

            hex = "0901";
            json = JT809Serializer.Analyze<JT809_0x9500_0x9502>(hex.ToHexBytes());

            hex = "0000014D010000000BBABA5F7366646633646673";
            json = JT809Serializer.Analyze<JT809_0x9500_0x9503>(hex.ToHexBytes());

            hex = "1018092720002018092723002015B4";
            json = JT809Serializer.Analyze<JT809_0x9500_0x9504>(hex.ToHexBytes());

            hex = "000000005EA577D4000000005EA5A20410";
            json = JT809_2019_Serializer.Analyze<JT809_0x9500_0x9504>(hex.ToHexBytes());

            hex = "000000000000000008086A743830380000000000000000000000000000006164736C736D616C6C636869000000000000000000000000000000000000000000000000000000000000000000000000006164736C3132330000000000000000000000000000003132372E302E302E31000000000000000000000000000000000000000000000003280329000000005BACC640";
            json = JT809Serializer.Analyze<JT809_0x9500_0x9505>(hex.ToHexBytes());

            
        }
    }
}
