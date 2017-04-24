using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EncodeEncrypt.Test
{
    [TestClass]
    public class EncodeEncryptTests
    {
        [TestMethod]
        public void TestWithFirstExample()
        {
            //Arrange
            string message = "TELERIKACADEMY";
            string cypher = "SOFTWARE";
            var expected = @"BKOXHI\EQOGX[YSOFTWARE8";
            //Act
            var textCypher = Program.Encrypt(message, cypher) + cypher;
            var result = Program.Encode(textCypher) + cypher.Length;

            //Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestWithSecondExample()
        {
            //Arrange
            string message = "AAABB";
            string cypher = "BBBBBBA";
            var expected = "ABBAA6BA7";
            //Act
            var textCypher = Program.Encrypt(message, cypher) + cypher;
            var result = Program.Encode(textCypher) + cypher.Length;

            //Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestWithThirdExample()
        {
            //Arrange
            string message = "JOHNY";
            string cypher = "DEPPP";
            var expected = "KKICXDE3P5";
            //Act
            var textCypher = Program.Encrypt(message, cypher) + cypher;
            var result = Program.Encode(textCypher) + cypher.Length;

            //Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestWithForthExample()
        {
            //Arrange
            string message = "THEQUICKBROWNFOX";
            string cypher = "JUMPSOVERTHELAZYDOG";
            var expected = @"Z^O`GGXOQCJSGFXPJUMPSOVERTHELAZYDOG19";
            //Act
            var textCypher = Program.Encrypt(message, cypher) + cypher;
            var result = Program.Encode(textCypher) + cypher.Length;

            //Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestWithFifthExample()
        {
            //Arrange
            string message = "CCCCCHHOH";
            string cypher = "HHO";
            var expected = "FFMFFJAJJHHO3";
            //Act
            var textCypher = Program.Encrypt(message, cypher) + cypher;
            var result = Program.Encode(textCypher) + cypher.Length;

            //Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestWithSixthExample()
        {
            //Arrange
            string message = "THEQUICKBROWNFOXTHEQUICKBROWNFOXTHEQUICKBROWNFOXTHEQUICKBROWNFOXTHEQUICKBROWNFOXTHEQUICKBROWNFOXTHEQUICKBROWNFOXTHEQUICKBROWNFOXTHEQUICKBROWNFOXTHEQUICKBROWNFOXTHEQUICKBROWNFOXTHEQUICKBROWNFOXTHEQUICKBROWNFOXTHEQUICKBROWNFOXTHEQUICKBROWNFOXTHEQUICKBROWNFOXTHEQUICKBROWNFOXTHEQUICKBROWNFOXTHEQUICKBROWNFOXTHEQUICKBROWNFOXTHEQUICKBROWNFOXTHEQUICKBROWNFOXTHEQUICKBROWNFOXTHEQUICKBROWNFOXTHEQUICKBROWNFOXTHEQUICKBROWNFOXTHEQUICKBROWNFOXTHEQUICKBROWNFOXTHEQUICKBROWNFOXTHEQUICKBROWNFOXTHEQUICKBROWNFOXTHEQUICKBROWNFOXTHEQUICKBROWNFOXTHEQUICKBROWNFOXTHEQUICKBROWNFOXTHEQUICKBROWNFOXTHEQUICKBROWNFOXTHEQUICKBROWNFOXTHEQUICKBROWNFOXTHEQUICKBROWNFOXTHEQUICKBROWNFOXTHEQUICKBROWNFOXTHEQUICKBROWNFOXTHEQUICKBROWNFOXTHEQUICKBROWNFOXTHEQUICKBROWNFOXTHEQUICKBROWNFOXTHEQUICKBROWNFOX";
            string cypher = "JUMPSJUUUUUUUUUUUMPSJUMPSJUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUMPSOVEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEER";
            var expected = @"[TI`GBW_VF[CZR[DHLLC^]OFTY[CZR[DHTQEA]W_VF[CZR[DHTQEA]W_VFCZ`L\TXDAUQMGOFVKSJBKTXDAUQMGOFVKSJBKTXDAUQMGOFVKSJBKG[TI`GBW_VF[CZR[DHLLC^]OFTY[CZR[DHTQEA]W_VF[CZR[DHTQEA]W_VFCZ`L\TXDAUQMGOFVKSJBKTXDAUQMGOFVKSJBKTXDAUQMGOFVKSJBKG[TI`GBW_VF[CZR[DHLLC^]OFTY[CZR[DHTQEA]W_VF[CZR[DHTQEA]W_VFCZ`L\TXDAUQMGOFVKSJBKTXDAUQMGOFVKSJBKTXDAUQMGOFVKSJBKG[TI`GBW_VF[CZR[DHLLC^]OFTY[CZR[DHTQEA]W_VF[CZR[DHTQEA]W_VFCZ`L\TXDAUQMGOFVKSJBKTXDAUQMGOFVKSJBKTXDAUQMGOFVKSJBKG[TI`GBW_VF[CZR[DHLLC^]OFTY[CZR[DHTQEA]W_VF[CZR[DHTQEA]W_VFCZ`L\TXDAUQMGOFVKSJBKTXDAUQMGOFVKSJBKTXDAUQMGOFVKSJBKG[TI`GBW_VF[CZR[DHLLC^]OFTY[CZR[DHTQEA]W_VF[CZR[DHTQEA]W_VFCZ`L\TXDAUQMGOFVKSJBKTXDAUQMGOFVKSJBKTXDAUQMGOFVKSJBKG[TI`GBW_VF[CZR[DHLLC^]OFTY[CZR[DHTQEA]W_VF[CZR[DHTQEA]W_VFCZ`L\TXDAUQMGOFVKSJBKTXDAUQMGOFVKSJBKTJUMPSJ11UMPSJUMPSJ32UMPSOV48ER112";
            //Act
            var textCypher = Program.Encrypt(message, cypher) + cypher;
            var result = Program.Encode(textCypher) + cypher.Length;

            //Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestWithSeventhExample()
        {
            //Arrange
            string message = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string cypher = "THATSTHEENGLISHALPHABETXYZ";
            var expected = @"TGCQWWBDMEMAE`JP\_VTVRF3ATHATSTHEENGLISHALPHABETXYZ26";
            //Act
            var textCypher = Program.Encrypt(message, cypher) + cypher;
            var result = Program.Encode(textCypher) + cypher.Length;

            //Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestWithEightExample()
        {
            //Arrange
            string message = "TONIIIIIIGHTONSIIIIILVERWIIIIIIIINGSANDIMSOARINGFORTHEMOUNTAINSONTHEMOON";
            string cypher = "BRUCEDICKINSONSILVERWINGS";
            var expected = @"S`ZKMLAKCOKB4AD^MZ^^JXEJZ]KMLAKHO`SDO[EZ\EA_FLD]QCTGIN]PZIF`]D`\MRI`YFBRUCEDICKINSONSILVERWINGS25";
            //Act
            var textCypher = Program.Encrypt(message, cypher) + cypher;
            var result = Program.Encode(textCypher) + cypher.Length;

            //Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestWithNinthExample()
        {
            //Arrange
            string message = "BEEEPBEEEPBEEEEEEEPBEEEEEEEEEP";
            string cypher = "SPUTNIKONEQUOTEWHICHAREBEEEEEEPLIKE";
            var expected = @"]AY^GJOKJLRQKXASDMNGEVAF5ALSPUTNIKONEQUOTEWHICHAREB6EPLIKE35";
            //Act
            var textCypher = Program.Encrypt(message, cypher) + cypher;
            var result = Program.Encode(textCypher) + cypher.Length;

            //Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestWithTenthExample()
        {
            //Arrange
            string message = "BBBBFSHARPFSHARPFSHARPFSHARPAAAAEEEEGGGGDDDDEEEE";
            string cypher = "CHORDSFORHOTELCALIFORNIAITHIIIIIINK";
            var expected = @"DGPQGACOAILBDLTPO[COACNSPTWH4IMJOGBIXFRGNSDKXACHORDSFORHOTELCALIFORNIAITH6INK35";
            //Act
            var textCypher = Program.Encrypt(message, cypher) + cypher;
            var result = Program.Encode(textCypher) + cypher.Length;

            //Assert
            Assert.AreEqual(expected, result);
        }
    }
}
