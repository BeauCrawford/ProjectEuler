﻿using NUnit.Framework;

namespace ProjectEuler.Tests
{
    [TestFixture]
    public class SodukoTests
    {
        [Test]
        public void Create_Board()
        {
            var board = SodukoBoard.Parse(@"003 020 600
                                            900 305 001
                                            001 806 400

                                            008 102 900
                                            700 000 008
                                            006 708 200

                                            002 609 500
                                            800 203 009
                                            005 010 300");
        }
    }
}
