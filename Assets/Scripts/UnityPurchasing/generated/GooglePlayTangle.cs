#if UNITY_ANDROID || UNITY_IPHONE || UNITY_STANDALONE_OSX || UNITY_TVOS
// WARNING: Do not modify! Generated file.

namespace UnityEngine.Purchasing.Security {
    public class GooglePlayTangle
    {
        private static byte[] data = System.Convert.FromBase64String("w0kP1ZUJVZ9VDT60Cnyq9+3SNZnxcnxzQ/FyeXHxcnJz19IKOwnWtD1YI9aMRZ0bRYcmThEgzIFAPw3LUHRtYZck1ZM4GEmkA+dOHrbIrcBummHETeK0Uvh0CoImp+gLlO082WIlAF/1/chWRJo2bRbAAPki5JUSexCGEpkXnxp4XC3e/cHIaNcrGsc+zOxwkQ+tuw5k1U8vIf70CELhURI6V3DoWdxTampmDDXDhy72mXql5uNpu/ox8joRTuYWBU+b8SV/wG5D8XJRQ351eln1O/WEfnJycnZzcCzCJwM5skm1R6jTmftOVVpYuh295ugdtT3noKKMFcmXntPGJDW36n5mj3uvt9PJbWbKp4MTtpdi+/R+XBewOlQve9ZTQHFwcnNy");
        private static int[] order = new int[] { 6,1,10,10,12,13,13,10,9,11,13,13,13,13,14 };
        private static int key = 115;

        public static readonly bool IsPopulated = true;

        public static byte[] Data() {
        	if (IsPopulated == false)
        		return null;
            return Obfuscator.DeObfuscate(data, order, key);
        }
    }
}
#endif
