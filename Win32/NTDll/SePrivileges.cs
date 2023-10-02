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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace Sudowin.Win32.NTDll
{
    /// <summary>
    /// The
    /// <see href="https://learn.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-token_groups#members">
    /// SeGroupAttributes
    /// </see>
    /// specify the attributes of a group.
    /// </summary>
    [Flags]
    public enum SeGroupAttributes : uint
    {
        Mandatory = 0x00000001,
        EnabledByDefault = 0x00000002,
        Enabled = 0x00000004,
        Owner = 0x00000008,
        UseForDenyOnly = 0x00000010,
        Integrity = 0x00000020,
        IntegrityEnabled = 0x00000040,
        Resource = 0x20000000,
        LogonId = 0xC0000000
    }

    /// <summary>
    /// The
    /// <see href="https://learn.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-token_privileges#members">
    /// SePrivilegeAttributes
    /// </see>
    /// specify the attributes of a privilege.
    /// </summary>
    [Flags]
    public enum SePrivilegeAttributes : uint
    {
        Enabled = 0x00000001,
        EnabledByDefault = 0x00000002,
        Removed = 0x00000004,
        UsedForAccess = 0x00000000
    }

    public static class SePrivileges
    {
        public const string SeCreateTokenPrivilege = "SeCreateTokenPrivilege";
        public const string SeAssignPrimaryTokenPrivilege = "SeAssignPrimaryTokenPrivilege";
        public const string SeLockMemoryPrivilege = "SeLockMemoryPrivilege";
        public const string SeIncreaseQuotaPrivilege = "SeIncreaseQuotaPrivilege";
        public const string SeMachineAccountPrivilege = "SeMachineAccountPrivilege";
        public const string SeTcbPrivilege = "SeTcbPrivilege";
        public const string SeSecurityPrivilege = "SeSecurityPrivilege";
        public const string SeTakeOwnershipPrivilege = "SeTakeOwnershipPrivilege";
        public const string SeLoadDriverPrivilege = "SeLoadDriverPrivilege";
        public const string SeSystemProfilePrivilege = "SeSystemProfilePrivilege";
        public const string SeSystemtimePrivilege = "SeSystemtimePrivilege";
        public const string SeProfileSingleProcessPrivilege = "SeProfileSingleProcessPrivilege";
        public const string SeIncreaseBasePriorityPrivilege = "SeIncreaseBasePriorityPrivilege";
        public const string SeCreatePagefilePrivilege = "SeCreatePagefilePrivilege";
        public const string SeCreatePermanentPrivilege = "SeCreatePermanentPrivilege";
        public const string SeBackupPrivilege = "SeBackupPrivilege";
        public const string SeRestorePrivilege = "SeRestorePrivilege";
        public const string SeShutdownPrivilege = "SeShutdownPrivilege";
        public const string SeDebugPrivilege = "SeDebugPrivilege";
        public const string SeAuditPrivilege = "SeAuditPrivilege";
        public const string SeSystemEnvironmentPrivilege = "SeSystemEnvironmentPrivilege";
        public const string SeChangeNotifyPrivilege = "SeChangeNotifyPrivilege";
        public const string SeRemoteShutdownPrivilege = "SeRemoteShutdownPrivilege";
        public const string SeUndockPrivilege = "SeUndockPrivilege";
        public const string SeSyncAgentPrivilege = "SeSyncAgentPrivilege";
        public const string SeEnableDelegationPrivilege = "SeEnableDelegationPrivilege";
        public const string SeManageVolumePrivilege = "SeManageVolumePrivilege";
        public const string SeImpersonatePrivilege = "SeImpersonatePrivilege";
        public const string SeCreateGlobalPrivilege = "SeCreateGlobalPrivilege";
        public const string SeTrustedCredManAccessPrivilege = "SeTrustedCredManAccessPrivilege";
        public const string SeRelabelPrivilege = "SeRelabelPrivilege";
        public const string SeIncreaseWorkingSetPrivilege = "SeIncreaseWorkingSetPrivilege";
        public const string SeTimeZonePrivilege = "SeTimeZonePrivilege";
        public const string SeCreateSymbolicLinkPrivilege = "SeCreateSymbolicLinkPrivilege";
        public const string SeDelegateSessionUserImpersonatePrivilege = "SeDelegateSessionUserImpersonatePrivilege";

        public static string[] AllNames()
        {
            return new string[]
            {
                SeCreateTokenPrivilege,
                SeAssignPrimaryTokenPrivilege,
                SeLockMemoryPrivilege,
                SeIncreaseQuotaPrivilege,
                SeMachineAccountPrivilege,
                SeTcbPrivilege,
                SeSecurityPrivilege,
                SeTakeOwnershipPrivilege,
                SeLoadDriverPrivilege,
                SeSystemProfilePrivilege,
                SeSystemtimePrivilege,
                SeProfileSingleProcessPrivilege,
                SeIncreaseBasePriorityPrivilege,
                SeCreatePagefilePrivilege,
                SeCreatePermanentPrivilege,
                SeBackupPrivilege,
                SeRestorePrivilege,
                SeShutdownPrivilege,
                SeDebugPrivilege,
                SeAuditPrivilege,
                SeSystemEnvironmentPrivilege,
                SeChangeNotifyPrivilege,
                SeRemoteShutdownPrivilege,
                SeUndockPrivilege,
                SeSyncAgentPrivilege,
                SeEnableDelegationPrivilege,
                SeManageVolumePrivilege,
                SeImpersonatePrivilege,
                SeCreateGlobalPrivilege,
                SeTrustedCredManAccessPrivilege,
                SeRelabelPrivilege,
                SeIncreaseWorkingSetPrivilege,
                SeTimeZonePrivilege,
                SeCreateSymbolicLinkPrivilege,
                SeDelegateSessionUserImpersonatePrivilege
            };
        }

        public static Dictionary<string,LUID> AllNamesAndValues()
        {
            var names = AllNames();
            var namesAndValues = new Dictionary<string, LUID>();

            for (int i = 0; i < names.Length; i++)
            {
                var luid = new LUID();
                if (!Advapi32.Native.LookupPrivilegeValue(
                    null,
                    names[i],
                    ref luid
                ))
                {
                    throw new Win32Exception(Marshal.GetLastWin32Error());
                }
                namesAndValues[names[i]] = luid;
            }

            return namesAndValues;
        }
    }
}
