using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Moq;
using HeadFirstDesignPattern.Facede.HomeTheater;

namespace UnitTestProject
{
    [TestClass]
    public class TestFacadeHomeTheater
    {
        const string AmplifierName = "home Theater";
        const string TurnerName = "Home Tuner";
        const string DvdPlayerName = "Home DVD Player";
        const string CdPlayerName = "Home CD Player";
        Amplifier amplifier_;
        Tuner tuner_;
        DvdPlayer dvd_player_;
        CdPlayer cd_player_;

        [TestInitialize]
        public void Setup()
        {
            amplifier_ = new Amplifier(AmplifierName);
            tuner_ = new Tuner(amplifier_, TurnerName);
            dvd_player_ = new DvdPlayer(amplifier_, DvdPlayerName);
            cd_player_ = new CdPlayer(amplifier_, CdPlayerName);
        }

        #region Test Amplifier
        [TestMethod]
        public void TestAmplifierOn()
        {
            string result = amplifier_.On();
            string expect = AmplifierName + " on\n";
            Assert.IsTrue(expect.Equals(result), "Expect[{0}] Result[{1}]", expect, result);
        }

        [TestMethod]
        public void TestAmplifierOff()
        {
            string result = amplifier_.Off();
            string expect = AmplifierName + " off\n";
            Assert.IsTrue(expect.Equals(result), "Expect[{0}] Result[{1}]", expect, result);
        }

        [TestMethod]
        public void TestAmplifierSetStereoSound()
        {
            string result = amplifier_.SetStereoSound();
            string expect = AmplifierName + " stereo mode on\n";
            Assert.IsTrue(expect.Equals(result), "Expect[{0}] Result[{1}]", expect, result);
        }

        [TestMethod]
        public void TestAmplifierSetSurroundSound()
        {
            string result = amplifier_.SetSurroundSound();
            string expect = AmplifierName + " surround sound on (5 speakers, 1 subwoofer)\n";
            Assert.IsTrue(expect.Equals(result), "Expect[{0}] Result[{1}]", expect, result);
        }

        [TestMethod]
        public void TestAmplifierSetVolume()
        {
            string result = amplifier_.SetVolume(50);
            string expect = string.Format("{0} setting volume to {1}\n", AmplifierName, 50);
            Assert.IsTrue(expect.Equals(result), "Expect[{0}] Result[{1}]", expect, result);
        }

        [TestMethod]
        public void TestAmplifierSetTuner()
        {
            string result = amplifier_.SetTuner(tuner_);
            string expect = string.Format("{0} setting tuner to {1}\n", AmplifierName, tuner_.Description);
            Assert.IsTrue(expect.Equals(result), "Expect[{0}] Result[{1}]", expect, result);
        }

        [TestMethod]
        public void TestAmplifierSetDvd()
        {
            string result = amplifier_.SetDvd(dvd_player_);
            string expect = string.Format("{0} setting DVD player to {1}\n", AmplifierName, dvd_player_.Description);
            Assert.IsTrue(expect.Equals(result), "Expect[{0}] Result[{1}]", expect, result);
        }

        [TestMethod]
        public void TestAmplifierSetCd()
        {
            string result = amplifier_.SetCd(cd_player_);
            string expect = string.Format("{0} setting CD player to {1}\n", AmplifierName, cd_player_.Description);
            Assert.IsTrue(expect.Equals(result), "Expect[{0}] Result[{1}]", expect, result);
        }
        #endregion

        #region CD Player
        [TestMethod]
        public void TestCdPlayerOff()
        {
            string result = cd_player_.Off();
            string expect = CdPlayerName + " off\n";
            Assert.IsTrue(expect.Equals(result), "Expect[{0}] Result[{1}]", expect, result);
        }

        [TestMethod]
        public void TestCdPlayerOn()
        {
            string result = cd_player_.On();
            string expect = CdPlayerName + " on\n";
            Assert.IsTrue(expect.Equals(result), "Expect[{0}] Result[{1}]", expect, result);
        }

        [TestMethod]
        public void TestCdPlayerEject()
        {
            string result = cd_player_.Eject();
            string expect = CdPlayerName + " eject\n";
            Assert.IsTrue(expect.Equals(result), "Expect[{0}] Result[{1}]", expect, result);
        }

        const string CD_TITLE = "Panic! At The Disco: That Green Gentleman";
        [TestMethod]
        public void TestCdPlayerPlayTitle()
        {
            string result = cd_player_.Play(CD_TITLE);
            string expect = string.Format("{0} playing \"{1}\"\n", CdPlayerName, CD_TITLE);
            Assert.IsTrue(expect.Equals(result), "Expect[{0}] Result[{1}]", expect, result);
        }

        [TestMethod]
        public void TestCdPlayerPlayTrackNG()
        {
            string result = cd_player_.Play(1);
            string expect = string.Format("{0} can't play track {1}, no cd inserted\n", CdPlayerName, 1);
            Assert.IsTrue(expect.Equals(result), "Expect[{0}] Result[{1}]", expect, result);
        }

        [TestMethod]
        public void TestCdPlayerPlayTrackOK()
        {
            string result_title = cd_player_.Play(CD_TITLE);
            string expect_title = string.Format("{0} playing \"{1}\"\n", CdPlayerName, CD_TITLE);
            Assert.IsTrue(expect_title.Equals(result_title), "Expect[{0}] Result[{1}]", expect_title, result_title);
            string result_track = cd_player_.Play(1);
            string expect_track = string.Format("{0} playing track {1}\n", CdPlayerName, 1);
            Assert.IsTrue(expect_track.Equals(result_track), "Expect[{0}] Result[{1}]", expect_track, result_track);
        }
        #endregion
    }
}
