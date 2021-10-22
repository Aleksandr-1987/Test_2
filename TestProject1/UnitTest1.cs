using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Test_2;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CountErrors()
        {
            List<Result> expected = new List<Result>
                {
                    new Result { Key = "Blocker", TEAM_BEAUJOLAIS = 6, TEAM_BORDEAUX = 1, TEAM_BURGUNDY = 0, TEAM_LOIRE = 6, TEAM_PROVENCE = 1, TEAM_RHONE = 1, MISC = 0, Total = 15},
                    new Result { Key = "Critical", TEAM_BEAUJOLAIS = 10, TEAM_BORDEAUX = 4, TEAM_BURGUNDY = 1, TEAM_LOIRE = 3, TEAM_PROVENCE = 1, TEAM_RHONE = 2, MISC = 0, Total = 21},
                    new Result { Key = "Major", TEAM_BEAUJOLAIS = 15, TEAM_BORDEAUX = 5, TEAM_BURGUNDY = 6, TEAM_LOIRE = 19, TEAM_PROVENCE = 0, TEAM_RHONE = 2, MISC = 0, Total = 47},
                    new Result { Key = "Medium", TEAM_BEAUJOLAIS = 0, TEAM_BORDEAUX = 0, TEAM_BURGUNDY = 0, TEAM_LOIRE = 3, TEAM_PROVENCE = 0, TEAM_RHONE = 0, MISC = 1, Total = 4},
                    new Result { Key = "Minor", TEAM_BEAUJOLAIS = 0, TEAM_BORDEAUX = 0, TEAM_BURGUNDY = 1, TEAM_LOIRE = 1, TEAM_PROVENCE = 1, TEAM_RHONE = 0, MISC = 0, Total = 3},
                    new Result { Key = "Normal", TEAM_BEAUJOLAIS = 0, TEAM_BORDEAUX = 0, TEAM_BURGUNDY = 0, TEAM_LOIRE = 0, TEAM_PROVENCE = 0, TEAM_RHONE = 0, MISC = 0, Total = 0},
                    new Result { Key = "Total", TEAM_BEAUJOLAIS = 31, TEAM_BORDEAUX = 10, TEAM_BURGUNDY = 8, TEAM_LOIRE = 32, TEAM_PROVENCE = 3, TEAM_RHONE = 5, MISC = 1, Total = 90},
                    new Result { Key = "Unresolved", TEAM_BEAUJOLAIS = 16, TEAM_BORDEAUX = 6, TEAM_BURGUNDY = 8, TEAM_LOIRE = 14, TEAM_PROVENCE = 0, TEAM_RHONE = 0, MISC = 0, Total = 44}
                };

            List<Result> actual = Funktions.CreateList();
            Funktions.FillList(ref actual);
            
            Assert.AreEqual(expected, actual);
        }
    }
}
