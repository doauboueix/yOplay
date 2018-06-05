using Microsoft.VisualStudio.TestTools.UnitTesting;
using SQL;
using System.Collections.Generic;
using ClassLibrary;

namespace UnitTestProject
{
    /// <summary>
    /// Description résumée pour TestMethod
    /// </summary>
    [TestClass]
    public class TestMethod
    {
        [TestMethod]
        public void TestInscription_Connexion()
        {
            SQLupdate SQLupdate = new SQLupdate();
            SQLupdate.Inscription("Jean", "Didier", "xXD4rk_JeanDidXx", "ToTheMoon");
            SQLselect SQLselect = new SQLselect();
            int i = SQLselect.SQLConnexion("xXD4rk_JeanDidXx", "ToTheMoon");
            Assert.IsTrue(i == 1);
        }



        [TestMethod]
        public void TestAjouterSolde()
        {
            SQLupdate SQLupdate = new SQLupdate();
            int i = SQLupdate.UpdateSolde("xXD4rk_JeanDidXx", 50);
            Assert.IsTrue(i == 1);
        }



        [TestMethod]
        public void TestAchatMusique()
        {
            SQLupdate SQLupdate = new SQLupdate();
            int i = SQLupdate.AcheterMusique("xXD4rk_JeanDidXx", 1.99M, "Havana");
            Assert.IsTrue(i == 1);
        }



        [TestMethod]
        public void TestAchatFilm()
        {
            SQLupdate SQLupdate = new SQLupdate();
            int i = SQLupdate.AchatFilm("xXD4rk_JeanDidXx", "Tomb Raider", 15.99M);
            Assert.IsTrue(i == 1);
        }



        [TestMethod]
        public void TestCreationPlaylist()
        {
            SQLupdate SQLupdate = new SQLupdate();
            int i = SQLupdate.AjouterPlaylist("xXD4rk_JeanDidXx", "Havana");
            Assert.IsTrue(i == 1);
        }



        [TestMethod]
        public void TestUpdatePlaylist()
        {
            SQLupdate SQLupdate = new SQLupdate();
            int i = SQLupdate.UpdatePlaylist("Playlist de xXD4rk_JeanDidXx");
            Assert.IsTrue(i == 1);
        }



        /*
        [TestMethod]
        public void TestDeletePlaylist()
        {
            SQLdelete SQLdelete = new SQLdelete();
            int i = SQLdelete.DeletePlaylist();
            Assert.IsTrue(i == 1);
        }



        [TestMethod]
        public void TestSupprimerPlaylist()
        {
            SQLdelete SQLdelete = new SQLdelete();
            int i = SQLdelete.SupprimerPlaylist("xXD4rk_JeanDidXx", "Playlist de xXD4rk_JeanDidXx");
            Assert.IsTrue(i == 1);
        }
        */



        [TestMethod]
        public void TestChargementMesFilms()
        {
            SQLselect SQLselect = new SQLselect();
            List<string> list = SQLselect.ChargementMesFilms("xXD4rk_JeanDidXx");
            Assert.IsTrue(list.Count > 0);
        }



        [TestMethod]
        public void TestChargementMesMusiques()
        {
            SQLselect SQLselect = new SQLselect();
            List<string> list = SQLselect.ChargementMesMusiques("xXD4rk_JeanDidXx");
            Assert.IsTrue(list.Count > 0);
        }



        /// <summary>
        /// Pour tester cette fonction, les fonctions TestDeletePlaylist() et TestSupprimerPlaylist() doivent être commentées,
        /// sinon cela ne fonctionnera pas car TestChargementMesPlaylists() n'aura aucune Playlist à alle charger
        /// </summary>
        [TestMethod]
        public void TestChargementMesPlaylists()
        {
            SQLselect SQLselect = new SQLselect();
            List<ListPlaylists> list = SQLselect.ChargementPlaylist("xXD4rk_JeanDidXx");
            Assert.IsTrue(list.Count > 0);
        }
    }
}
