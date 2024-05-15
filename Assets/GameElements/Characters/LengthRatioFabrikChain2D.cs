#region Assembly Unity.2D.IK.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// location unknown
// Decompiled with ICSharpCode.Decompiler 8.1.1.7464
#endregion

using UnityEngine.Scripting.APIUpdating;

namespace UnityEngine.U2D.IK
{
    [MovedFrom("UnityEngine.Experimental.U2D.IK")]
    public struct LengthRatioFabrikChain2D
    {
        public Vector2 origin;

        public Vector2 target;

        public float sqrTolerance;

        public Vector2[] positions;

        public float[] lengths;
        
        public float[] lenghtRatios;

        public int[] subChainIndices;

        public Vector3[] worldPositions;

        public Vector2 first => positions[0];

        public Vector2 last => positions[^1];
    }
    
#if false // Decompilation log
    '244' items in cache
    ------------------
    Resolve: 'netstandard, Version=2.1.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51'
    Found single assembly: 'netstandard, Version=2.1.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51'
    Load from: 'C:\Program Files\Unity\Hub\Editor\2022.3.19f1\Editor\Data\NetStandard\ref\2.1.0\netstandard.dll'
    ------------------
    Resolve: 'UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null'
    Found single assembly: 'UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null'
    Load from: 'C:\Program Files\Unity\Hub\Editor\2022.3.19f1\Editor\Data\Managed\UnityEngine\UnityEngine.CoreModule.dll'
    ------------------
    Resolve: 'Unity.InternalAPIEngineBridge.001, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null'
    Found single assembly: 'Unity.InternalAPIEngineBridge.001, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null'
    Load from: 'C:\Users\thead\Documents\Code\UACH-EatingDrops\Library\ScriptAssemblies\Unity.InternalAPIEngineBridge.001.dll'
    ------------------
    Resolve: 'UnityEngine.AnimationModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null'
    Found single assembly: 'UnityEngine.AnimationModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null'
    Load from: 'C:\Program Files\Unity\Hub\Editor\2022.3.19f1\Editor\Data\Managed\UnityEngine\UnityEngine.AnimationModule.dll'
    ------------------
    Resolve: 'UnityEngine.IMGUIModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null'
    Found single assembly: 'UnityEngine.IMGUIModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null'
    Load from: 'C:\Program Files\Unity\Hub\Editor\2022.3.19f1\Editor\Data\Managed\UnityEngine\UnityEngine.IMGUIModule.dll'
    ------------------
    Resolve: 'System.Runtime.InteropServices, Version=2.1.0.0, Culture=neutral, PublicKeyToken=null'
    Found single assembly: 'System.Runtime.InteropServices, Version=4.1.2.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
    WARN: Version mismatch. Expected: '2.1.0.0', Got: '4.1.2.0'
    Load from: 'C:\Program Files\Unity\Hub\Editor\2022.3.19f1\Editor\Data\NetStandard\compat\2.1.0\shims\netstandard\System.Runtime.InteropServices.dll'
    ------------------
    Resolve: 'System.Runtime.CompilerServices.Unsafe, Version=2.1.0.0, Culture=neutral, PublicKeyToken=null'
    Could not find by name: 'System.Runtime.CompilerServices.Unsafe, Version=2.1.0.0, Culture=neutral, PublicKeyToken=null'
#endif
}
