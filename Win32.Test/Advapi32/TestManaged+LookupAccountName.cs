/*
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
using System;
using System.Security.Principal;

namespace Sudowin.Win32.Test.Advapi32
{
    public partial class Managed
    {
        [TestMethod]
        public void TestLookupAccountName_CurrentUser()
        {
            (
                _,
                string referencedDomainName,
                SIDNameUse sidNameUse
            ) = Win32.Advapi32.Managed.LookupAccountName(Environment.UserName);

            Assert.AreEqual(Environment.MachineName, referencedDomainName);
            Assert.AreEqual(SIDNameUse.User, sidNameUse);
        }

        [TestMethod]
        public void TestLookupAccountName_LocalAdmin()
        {
            (
                SafeGlobalIntPtr pSid,
                string referencedDomainName,
                SIDNameUse sidNameUse
            ) = Win32.Advapi32.Managed.LookupAccountName("Administrator");

            Assert.AreEqual(Environment.MachineName, referencedDomainName);
            Assert.AreEqual(SIDNameUse.User, sidNameUse);
            var sid = new SecurityIdentifier(pSid);
            Assert.IsTrue(sid.IsWellKnown(WellKnownSidType.AccountAdministratorSid));
        }

        [TestMethod]
        public void TestLookupAccountName_LocalAdminGroup()
        {
            (
                SafeGlobalIntPtr pSid,
                string referencedDomainName,
                SIDNameUse sidNameUse
            ) = Win32.Advapi32.Managed.LookupAccountName("Administrators");

            Assert.AreEqual("BUILTIN", referencedDomainName);
            Assert.AreEqual(SIDNameUse.Alias, sidNameUse);
            var sid = new SecurityIdentifier(pSid);
            Assert.IsTrue(sid.IsWellKnown(WellKnownSidType.BuiltinAdministratorsSid));
        }
    }
}
