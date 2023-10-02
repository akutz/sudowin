﻿/*
Copyright (c) 2005-2023, Schley Andrew Kutz <sakutz@gmail.com>
All rights reserved.
Redistribution and use in source and binary forms, with or without modification,
are permitted provided that the following conditions are met:

    * Redistributions of source code must retain the above copyright notice,
    this list of conditions and the following disclaimer.
    * Redistributions in binary form must reproduce the above copyright notice,
    this list of conditions and the following disclaimer in the documentation
    and/or other materials provided with the distribution.
    * Neither the name of Andrew Kutz nor the names of its contributors may
    be used to endorse or promote products derived from this software without
    specific prior written permission.

THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND
ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED
WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE FOR
ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES
(INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;
LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON
ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
(INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS
SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
*/

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sudowin.Win32.NTDll;

namespace Sudowin.Win32.Test.NTDll
{
    public partial class Default
    {
        [TestMethod]
        public void TestNTStatusException_DatatypeMisalignment()
        {
            var ex = new NtStatusException(NTStatus.DatatypeMisalignment);
            Assert.IsNotNull(ex);
            Assert.AreEqual(
                NTStatus.DatatypeMisalignment,
                (NTStatus)ex.NativeErrorCode
            );
            Assert.AreEqual(
                "{EXCEPTION}\r\nAlignment Fault\r\nA datatype misalignment " +
                "was detected in a load or store instruction.\r\n",
                ex.Message
            );
        }

        [TestMethod]
        public void TestNTStatusException_PrivilegeNotHeld()
        {
            var ex = new NtStatusException(NTStatus.PrivilegeNotHeld);
            Assert.IsNotNull(ex);
            Assert.AreEqual(
                NTStatus.PrivilegeNotHeld,
                (NTStatus) ex.NativeErrorCode
            );
            Assert.AreEqual(
                "A required privilege is not held by the client.\r\n",
                ex.Message
            );
        }

    }
}