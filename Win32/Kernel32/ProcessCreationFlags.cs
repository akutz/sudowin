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

namespace Sudowin.Win32.Kernel32
{
    /// <summary>
    /// The following process creation flags are used by the CreateProcess and
    /// CreateProcessAsUser functions. They can be specified in any combination,
    /// except as noted.
    /// </summary>
    /// <remarks>
    /// On 32-bit Windows, 16-bit applications are simulated by ntvdm.exe, not run as
    /// individual processes. Therefore, the process creation flags apply to ntvdm.exe.
    /// Because ntvdm.exe persists after you run the first 16-bit application, when you
    /// launch another 16-bit application, the new creation flags are not applied, except
    /// for CreateNewConsole and CreateSeperateWowVdm, which create a new ntvdm.exe.
    /// 
    /// Process Creation Flags, https://learn.microsoft.com/en-us/windows/win32/procthread/process-creation-flags
    /// </remarks>
    [Flags]
    public enum ProcessCreationFlags : uint
    {
        /// <summary>
        /// The child processes of a process associated with a job are not associated with the job.
        /// 
        /// If the calling process is not associated with a job, this constant has no effect.
        /// If the calling process is associated with a job, the job must set the
        /// JobObjectLimitBreakawayOk limit.
        /// </summary>
        /// <remarks>
        /// Windows NT and Windows Me/98/95:  This value is not supported.
        /// </remarks>
        CreateBreakwayFromJob = 0x01000000,
        /// <summary>
        /// The new process does not inherit the error mode of the calling process.
        /// Instead, the new process gets the default error mode.
        ///
        /// This feature is particularly useful for multi-threaded shell applications
        /// that run with hard errors disabled.
        /// 
        /// The default behavior is for the new process to inherit the error mode of
        /// the caller. Setting this flag changes that default behavior.
        /// </summary>
        CreateDefaultErrorMode = 0x04000000,
        /// <summary>
        /// The new process has a new console, instead of inheriting its parent's console
        /// (the default). For more information, see Creation of a Console, http://msdn.microsoft.com/library/en-us/dllproc/base/creation_of_a_console.asp.
        ///
        /// This flag cannot be used with CreateNoWindow or DetachedProcess.
        /// </summary>
        CreateNewConsole = 0x00000010,
        /// <summary>
        /// The new process is the root process of a new process group. The process group
        /// includes all processes that are descendants of this root process. The process
        /// identifier of the new process group is the same as the process identifier, which is
        /// returned in the lpProcessInformation parameter. Process groups are used by the
        /// GenerateConsoleCtrlEvent function to enable sending a CTRL+BREAK signal to a group
        /// of console processes.
        ///
        /// If this flag is specified, CTRL+C signals will be disabled for all processes within
        /// the new process group.
        ///
        /// Windows Server 2003:  This flag is ignored if specified with CreateNewConsole.
        /// </summary>
        CreateNewProcessGroup = 0x00000200,
        /// <summary>
        /// The process is a console application that is run without a console window.
        /// This flag is valid only when starting a console application.
        ///
        /// This flag cannot be used with CreateNewConsole or DetachedProcess or when starting
        /// an MS-DOS-based application.
        /// </summary>
        /// <remarks>
        /// Windows Me/98/95:  This value is not supported.
        /// </remarks>
        CreateNoWindow = 0x08000000,
        /// <summary>
        /// Allows the caller to execute a child process that bypasses the process
        /// restrictions that would normally be applied automatically to the process.
        /// </summary>
        /// <remarks>
        /// Windows 2000/NT and Windows Me/98/95:  This value is not supported.
        /// </remarks>
        CreatePreserveCodeAuthzLevel = 0x02000000,
        /// <summary>
        /// This flag is valid only when starting a 16-bit Windows-based application.
        /// If set, the new process runs in a private Virtual DOS Machine (VDM).
        /// By default, all 16-bit Windows-based applications run as threads in a single,
        /// shared VDM. The advantage of running separately is that a crash only terminates
        /// the single VDM; any other programs running in distinct VDMs continue to function
        /// normally. Also, 16-bit Windows-based applications that are run in separate VDMs
        /// have separate input queues. That means that if one application stops responding
        /// momentarily, applications in separate VDMs continue to receive input. The disadvantage
        /// of running separately is that it takes significantly more memory to do so. You
        /// should use this flag only if the user requests that 16-bit applications should run
        /// in their own VDM.
        /// </summary>
        /// <remarks>
        /// Windows Me/98/95:  This value is not supported.
        ///	</remarks>
        CreateSeperateWowVdm = 0x00000800,
        /// <summary>
        /// The flag is valid only when starting a 16-bit Windows-based application.
        /// If the DefaultSeparateVDM switch in the Windows section of WIN.INI is TRUE,
        /// this flag overrides the switch. The new process is run in the shared Virtual DOS Machine.
        /// </summary>
        /// <remarks>
        /// Windows Me/98/95:  This value is not supported.
        ///	</remarks>
        CreateSharedWowVdm = 0x00001000,
        /// <summary>
        /// The primary thread of the new process is created in a suspended state,
        /// and does not run until the ResumeThread function is called.
        /// </summary>
        CreateSuspended = 0x00000004,
        /// <summary>
        /// If this flag is set, the environment block pointed to by environment uses Unicode
        /// characters. Otherwise, the environment block uses ANSI characters.
        /// </summary>
        /// <remarks>
        /// Windows Me/98/95:  This value is not supported.
        ///	</remarks>
        CreateUnicodeEnvironment = 0x00000400,
        /// <summary>
        /// The calling thread starts and debugs the new process. It can receive all related
        /// debug events using the WaitForDebugEvent function.
        /// </summary>
        DebugOnlyThisProcess = 0x00000002,
        /// <summary>
        /// The calling thread starts and debugs the new process and all any child processes
        /// of the new process that are created with DebugProcess. It can receive all related
        /// debug events using the WaitForDebugEvent function.
        ///
        /// If this flag is combined with DebugOnlyThisProcess, the caller debugs only
        /// the new process.
        /// </summary>
        /// <remarks>
        /// Windows Me/98/95:  This flag is not valid if the new process is a 16-bit application.
        /// </remarks>
        DebugProcess = 0x00000001,
        /// <summary>
        /// For console processes, the new process does not inherit its parent's console
        /// (the default). The new process can call the AllocConsole function at a later
        /// time to create a console. For more information, see Creation of a Console.
        ///
        /// This value cannot be used with CreateNewConsole or CreateNoWindow.
        /// </summary>
        DetachedProcess = 0x00000008,
    }
}
