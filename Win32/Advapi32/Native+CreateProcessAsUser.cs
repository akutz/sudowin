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
using System.Runtime.InteropServices;
using System.Security;

namespace Sudowin.Win32.Advapi32
{
    public static partial class Native
    {
        /// <summary>
        /// The
        /// <see href="https://learn.microsoft.com/en-us/windows/win32/api/processthreadsapi/nf-processthreadsapi-createprocessasuserw">
        /// CreateProcessAsUser
        /// </see>
        /// function creates a new process and its
        /// primary thread. The new process then runs the specified executable file.
        /// <para>
        /// The CreateProcessAsUser function is similar to the CreateProcess function,
        /// except that the new process runs in the security context of the user
        /// represented by the userToken parameter. This function is also similar to
        /// the SHCreateProcessAsUserW function.
        /// </para>
        /// </summary>
        /// <param name="userToken">
        /// Handle to a primary token that represents a user. The handle must have
        /// the TokenQuery, TokenDuplicate, and TokenAssignPrimary access rights.
        /// For more information, see Access Rights for Access-Token Objects.
        /// The user represented by the token must have read and execute access to
        /// the application specified by the applicationName or the commandLine parameter.
        ///
        /// To get a primary token that represents the specified user, call the
        /// LogonUser function. Alternatively, you can call the DuplicateTokenEx function
        /// to convert an impersonation token into a primary token. This allows a server
        /// application that is impersonating a client to create a process that has the
        /// security context of the client.
        ///
        /// Terminal Services:  The process is run in the session specified in the
        /// token. By default, this is the same session that called LogonUser.
        /// To change the session, use the SetTokenInformation function.
        /// </param>
        /// <param name="applicationName">
        /// A string that specifies the module to execute. The specified module can
        /// be a Windows-based application. It can be some other type of module
        /// (for example, MS-DOS or OS/2) if the appropriate subsystem is available
        /// on the local computer.
        ///
        /// The string can specify the full path and file name of the module to
        /// execute or it can specify a partial name. In the case of a partial name,
        /// the function uses the current drive and current directory to complete the
        /// specification. The function will not use the search path. If the file name
        /// does not contain an extension, .exe is assumed. Therefore, if the file
        /// name extension is .com, this parameter must include the .com extension.
        ///
        /// The applicationName parameter can be NULL. In that case, the module
        /// name must be the first white space-delimited token in the commandLine
        /// string. If you are using a long file name that contains a space,
        /// use quoted strings to indicate where the file name ends and the arguments
        /// begin; otherwise, the file name is ambiguous. For example, consider
        /// the string "c:\program files\sub dir\program name". This string can be
        /// interpreted in a number of ways. The system tries to interpret the
        /// possibilities in the following order:
        ///
        /// <code>
        ///     c:\program.exe files\sub dir\program name
        ///     c:\program files\sub.exe dir\program name
        ///     c:\program files\sub dir\program.exe name
        ///     c:\program files\sub dir\program name.exe
        /// </code>
        ///
        /// If the executable module is a 16-bit application, applicationName should be
        /// NULL, and the string pointed to by commandLine should specify the executable
        /// module as well as its arguments. By default, all 16-bit Windows-based
        /// applications created by CreateProcessAsUser are run in a separate VDM
        /// (equivalent to CreateSeperateWowVdm in CreateProcess).
        /// </param>
        /// <param name="commandLine">
        /// A string that specifies the command line to execute. The maximum length of
        /// this string is 32,000 characters.
        ///
        /// Windows 2000:  The maximum length of this string is MaxPath characters.
        ///
        /// The Unicode version of this function, CreateProcessAsUserW, will fail
        /// if this parameter is a const string.
        ///
        /// The commandLine parameter can be NULL. In that case, the function uses
        /// the string pointed to by applicationName as the command line.
        ///
        /// If both applicationName and commandLine are non-NULL, *applicationName
        /// specifies the module to execute, and *commandLine specifies the command line.
        /// The new process can use GetCommandLine to retrieve the entire command line.
        /// Console processes written in C can use the argc and argv arguments to parse
        /// the command line. Because argv[0] is the module name, C programmers generally
        /// repeat the module name as the first token in the command line.
        ///
        /// If applicationName is NULL, the first white-space – delimited token of
        /// the command line specifies the module name. If you are using a long file name
        /// that contains a space, use quoted strings to indicate where the file name ends
        /// and the arguments begin (see the explanation for the lpApplicationName parameter).
        /// If the file name does not contain an extension, .exe is appended. Therefore,
        /// if the file name extension is .com, this parameter must include the .com extension.
        /// If the file name ends in a period (.) with no extension, or if the file name
        /// contains a path, .exe is not appended. If the file name does not contain a
        /// directory path, the system searches for the executable file in the following sequence:
        ///
        ///     1. The directory from which the application loaded.
        ///
        ///     2. The current directory for the parent process.
        ///
        ///     3. The 32-bit Windows system directory. Use the GetSystemDirectory
        ///        function to get the path of this directory.
        ///
        ///     4. The 16-bit Windows system directory. There is no function
        ///        that obtains the path of this directory, but it is searched.
        ///
        ///     5. The Windows directory. Use the GetWindowsDirectory function
        ///        to get the path of this directory.
        ///
        ///     6. The directories that are listed in the PATH environment
        ///        variable.
        ///
        /// The system adds a null character to the command line string to separate the
        /// file name from the arguments. This divides the original string into two
        /// strings for internal processing.
        /// </param>
        /// <param name="processAttributes">
        /// Pointer to a SecurityAttributes structure that specifies a security
        /// descriptor for the new process and determines whether child processes
        /// can inherit the returned handle. If lpProcessAttributes is NULL or
        /// SecurityDescriptor is NULL, the process gets a default security descriptor
        /// and the handle cannot be inherited. The default security descriptor is
        /// that of the user referenced in the hToken parameter. This security
        /// descriptor may not allow access for the caller, in which case the
        /// process may not be opened again after it is run. The process handle
        /// is valid and will continue to have full access rights.
        /// </param>
        /// <param name="threadAttributes">
        /// Pointer to a SecurityAttributes structure that specifies a security
        /// descriptor for the new process and determines whether child processes
        /// can inherit the returned handle. If ThreadAttributes is NULL or
        /// SecurityDescriptor is NULL, the thread gets a default security descriptor
        /// and the handle cannot be inherited. The default security descriptor
        /// is that of the user referenced in the hToken parameter. This security
        /// descriptor may not allow access for the caller.
        /// </param>
        /// <param name="inheritHandles">
        /// If this parameter is TRUE, each inheritable handle in the calling process
        /// is inherited by the new process. If the parameter is FALSE, the handles
        /// are not inherited. Note that inherited handles have the same value and
        /// access rights as the original handles.
        ///
        /// Terminal Services:  You cannot inherit handles across sessions. Additionally,
        /// if this parameter is TRUE, you must create the process in the same session
        /// as the caller.
        /// </param>
        /// <param name="creationFlags">
        /// Flags that control the priority class and the creation of the process.
        /// For a list of values, see Process Creation Flags.
        ///
        /// This parameter also controls the new process's priority class, which
        /// is used to determine the scheduling priorities of the process's threads.
        /// For a list of values, see GetPriorityClass. If none of the priority class
        /// flags is specified, the priority class defaults to NormalPriorityClass unless
        /// the priority class of the creating process is IdlePriorityClass or
        /// BelowNormalPriorityClass. In this case, the child process receives the
        /// default priority class of the calling process.
        /// </param>
        /// <param name="environment">
        /// Pointer to an environment block for the new process. If this parameter is NULL,
        /// the new process uses the environment of the calling process.
        ///
        /// An environment block consists of a null-terminated block of strings.
        /// Each string is in the form:
        ///
        /// <code>name=value</code>
        ///
        /// Because the equal sign is used as a separator, it must not be used in the
        /// name of an environment variable.
        ///
        /// An environment block can contain either Unicode or ANSI characters. If
        /// the environment block pointed to by environment contains Unicode characters,
        /// be sure that creationFlags includes CreateUnicodeEnvironment.
        ///
        /// Note that an ANSI environment block is terminated by two zero bytes: one for
        /// the last string, one more to terminate the block. A Unicode environment
        /// block is terminated by four zero bytes: two for the last string, two more
        /// to terminate the block.
        ///
        /// To retrieve a copy of the environment block for a given user, use the
        /// CreateEnvironmentBlock function.
        /// </param>
        /// <param name="currentDirectory">
        /// Pointer to a null-terminated string that specifies the full path to the current
        /// directory for the process. The string can also specify a UNC path.
        ///
        /// If this parameter is NULL, the new process will have the same current drive
        /// and directory as the calling process. (This feature is provided primarily for
        /// shells that need to start an application and specify its initial drive
        /// and working directory.)
        /// </param>
        /// <param name="startupInfo">
        /// Pointer to a StartupInfo structure that specifies the window station,
        /// desktop, standard handles, and appearance of the main window for the new process.
        /// </param>
        /// <param name="processInformation">
        /// Pointer to a ProcessInformation structure that receives identification
        /// information about the new process.
        ///
        /// Handles in ProcessInformation must be closed with CloseHandle when
        /// they are no longer needed.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is nonzero.
        ///
        /// If the function fails, the return value is zero. To get extended error
        /// information, call GetLastError.
        /// </returns>
        /// <remarks>
        /// <para>
        /// Typically, the process that calls the CreateProcessAsUser function must have the
        /// SE_ASSIGNPRIMARYTOKEN_NAME and SE_INCREASE_QUOTA_NAME privileges. However, if
        /// userToken is a restricted version of the caller's primary token, the
        /// SE_ASSIGNPRIMARYTOKEN_NAME privilege is not required. If the necessary privileges
        /// are not already enabled, CreateProcessAsUser enables them for the duration of the
        /// call. For more information, see Running with Special Privileges, http://msdn.microsoft.com/library/en-us/secbp/security/running_with_special_privileges.asp.
        /// </para>
        /// <para>
        /// CreateProcessAsUser must be able to open the primary token of the calling process
        /// with the TOKEN_DUPLICATE and TOKEN_IMPERSONATE access rights.
        /// </para>
        /// <para>
        /// By default, CreateProcessAsUser creates the new process on a noninteractive window
        /// station with a desktop that is not visible and cannot receive user input. To
        /// enable user interaction with the new process, you must specify the name of the
        /// default interactive window station and desktop, "winsta0\default", in the
        /// lpDesktop member of the StartupInfo structure. In addition, before calling
        /// CreateProcessAsUser, you must change the discretionary access control list (DACL) 
        /// of both the default interactive window station and the default desktop.
        /// The DACLs for the window station and desktop must grant access to the user or
        /// the logon session represented by the userToken parameter.
        /// </para>
        /// <para>
        /// CreateProcessAsUser does not load the specified user's profile into the
        /// HKEY_USERS registry key. Therefore, to access the information in the
        /// HKEY_CURRENT_USER registry key, you must load the user's profile information
        /// into HKEY_USERS with the LoadUserProfile function before calling CreateProcessAsUser.
        /// Be sure to call UnloadUserProfile after the new process exits.
        /// </para>
        /// <para>
        /// If the environment parameter is NULL, the new process inherits the environment
        /// of the calling process. CreateProcessAsUser does not automatically modify the
        /// environment block to include environment variables specific to the user
        /// represented by hToken. For example, the USERNAME and USERDOMAIN variables are
        /// inherited from the calling process if lpEnvironment is NULL. It is your
        /// responsibility to prepare the environment block for the new process and specify
        /// it in environment.
        /// </para>
        /// <para>
        /// The CreateProcessWithLogonW and CreateProcessWithTokenW functions are similar
        /// to CreateProcessAsUser, except that the caller does not need to call the LogonUser
        /// function to authenticate the user and get a token.
        /// </para>
        /// <para>
        /// CreateProcessAsUser allows you to access the specified directory and executable image
        /// in the security context of the caller or the target user. By default,
        /// CreateProcessAsUser accesses the directory and executable image in the security
        /// context of the caller. In this case, if the caller does not have access to the
        /// directory and executable image, the function fails. To access the directory and
        /// executable image using the security context of the target user, specify userToken
        /// in a call to the ImpersonateLoggedOnUser function before calling CreateProcessAsUser.
        /// </para>
        /// <para>
        /// The process is assigned a process identifier. The identifier is valid until
        /// the process terminates. It can be used to identify the process, or specified in
        /// the OpenProcess function to open a handle to the process. The initial thread in
        /// the process is also assigned a thread identifier. It can be specified in the
        /// OpenThread function to open a handle to the thread. The identifier is valid
        /// until the thread terminates and can be used to uniquely identify the thread
        /// within the system. These identifiers are returned in the ProcessInformation structure.
        /// </para>
        /// <para>
        /// The calling thread can use the WaitForInputIdle function to wait until the
        /// new process has finished its initialization and is waiting for user input
        /// with no input pending. This can be useful for synchronization between parent
        /// and child processes, because CreateProcessAsUser returns without waiting for
        /// the new process to finish its initialization. For example, the creating process
        /// would use WaitForInputIdle before trying to find a window associated with the new process.
        /// </para>
        /// <para>
        /// The preferred way to shut down a process is by using the ExitProcess function, because
        /// this function sends notification of approaching termination to all DLLs attached to
        /// the process. Other means of shutting down a process do not notify the attached DLLs.
        /// Note that when a thread calls ExitProcess, other threads of the process are terminated
        /// without an opportunity to execute any additional code (including the thread termination
        /// code of attached DLLs). For more information, see Terminating a Process, http://msdn.microsoft.com/library/en-us/dllproc/base/terminating_a_process.asp.
        /// </para>
        /// <para>
        /// Security Remarks
        ///
        /// The applicationName parameter can be NULL, in which case the executable name must
        /// be the first white space-delimited string in commandLine. If the executable or
        /// path name has a space in it, there is a risk that a different executable could be
        /// run because of the way the function parses spaces. The following example is dangerous
        /// because the function will attempt to run "Program.exe", if it exists,
        /// instead of "MyApp.exe".
        ///
        /// <code>CreateProcessAsUser(hToken, NULL, "C:\\Program Files\\MyApp", ...)</code>
        /// </para>
        /// <para>
        /// If a malicious user were to create an application called "Program.exe" on a system,
        /// any program that incorrectly calls CreateProcessAsUser using the Program Files
        /// directory will run this application instead of the intended application.
        /// </para>
        /// <para>
        /// To avoid this problem, do not pass NULL for lpApplicationName. If you do pass NULL
        /// for applicationName, use quotation marks around the executable path in commandLine,
        /// as shown in the example below.
        ///
        /// <code>CreateProcessAsUser(hToken, NULL, "\"C:\\Program Files\\MyApp.exe\"", ...)</code>
        /// </para>
        /// </remarks>
        [DllImport(
            "advapi32.dll",
            EntryPoint = "CreateProcessAsUserW",
            CharSet = CharSet.Unicode,
            SetLastError = true),
            SuppressUnmanagedCodeSecurity
        ]
        public static extern bool CreateProcessAsUser(
            IntPtr userToken,
            [MarshalAs(UnmanagedType.LPWStr)] string applicationName,
            [MarshalAs(UnmanagedType.LPWStr)] ref string commandLine,
            Kernel32.SecurityAttributes processAttributes,
            Kernel32.SecurityAttributes threadAttributes,
            bool inheritHandles,
            uint creationFlags,
            IntPtr environment,
            [MarshalAs(UnmanagedType.LPWStr)] string currentDirectory,
            Kernel32.StartupInfo startupInfo,
            out Kernel32.ProcessInformation processInformation);
    }
}
