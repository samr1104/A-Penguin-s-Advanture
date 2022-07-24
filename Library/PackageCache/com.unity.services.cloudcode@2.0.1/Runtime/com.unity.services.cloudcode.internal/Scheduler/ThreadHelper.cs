//-----------------------------------------------------------------------------
// <auto-generated>
//     This file was generated by the C# SDK Code Generator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//-----------------------------------------------------------------------------


using System.Threading;
using UnityEditor;
using UnityEngine;

namespace Unity.Services.CloudCode.Internal.Scheduler
{
    internal static class ThreadHelper
    {
        public static SynchronizationContext SynchronizationContext => _unitySynchronizationContext;
        public static System.Threading.Tasks.TaskScheduler TaskScheduler => _taskScheduler;
        public static int MainThreadId => _mainThreadId;

        private static SynchronizationContext _unitySynchronizationContext;
        private static System.Threading.Tasks.TaskScheduler _taskScheduler;
        private static int _mainThreadId;

#if UNITY_EDITOR
        [InitializeOnLoadMethod]
#endif
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        public static void Init()
        {
            _unitySynchronizationContext = SynchronizationContext.Current;
            _taskScheduler = System.Threading.Tasks.TaskScheduler.FromCurrentSynchronizationContext();
            _mainThreadId = Thread.CurrentThread.ManagedThreadId;
        }
    }
}
