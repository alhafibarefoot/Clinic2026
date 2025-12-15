namespace Clinic2026_API.Services;

public interface IEncryptionService
{
    string Encrypt(string data);
    string Decrypt(string data);
}

public class EncryptionService : IEncryptionService
{
    // Updated CodeKey based on user provided example (Alhafi)
    private const string CodeKey = "Alhafi";

    public string Encrypt(string dataIn)
    {
        if (string.IsNullOrEmpty(dataIn)) return string.Empty;

        var strDataOut = new System.Text.StringBuilder();
        int keyLen = CodeKey.Length;

        for (int i = 0; i < dataIn.Length; i++)
        {
            // intXOrValue1 = Asc(Mid$(DataIn, arkdata1, 1)) -> char at i
            int value1 = (int)dataIn[i];

            // intXOrValue2 = Asc(Mid$(CodeKey, ((arkdata1 Mod Len(CodeKey)) + 1), 1))
            // arkdata1 is 1-based index equivalent to i + 1
            // Logic: ( (i+1) % KeyLen ) -> if 0 then KeyLen else result?
            // VBA Mod 5: 1%5=1, 2%5=2, 3%5=3, 4%5=4, 5%5=0.
            // VBA logic: ((arkdata1 Mod Len) + 1).
            // i=0 (ark=1): (1%Len)+1.
            // i=Len-1 (ark=Len): (Len%Len)+1 = 0+1 = 1.
            // i=Len (ark=Len+1): ((Len+1)%Len)+1 = 1+1 = 2.

            // C# equivalent:
            // i=0: index should be (1%3)+1 = 2 (1-based) => index 1 (0-based)
            // But wait, my previous analysis:
            // VBA "ABC" (Len=3). CodeKey indices 1,2,3.
            // ark=1: (1%3)+1=2 -> 'B' (index 1).
            // ark=2: (2%3)+1=3 -> 'C' (index 2).
            // ark=3: (3%3)+1=1 -> 'A' (index 0).

            // So indices are 1, 2, 0, 1, 2, 0...

            int keyIndex = ((i + 1) % keyLen);
            // If i=0 (ark=1), index=1. Correct.
            // If i=2 (ark=3), index=0. Correct.

            int value2 = (int)CodeKey[keyIndex];

            int temp = value1 ^ value2;
            strDataOut.Append(temp.ToString("X2"));
        }

        return strDataOut.ToString();
    }

    public string Decrypt(string dataIn)
    {
        if (string.IsNullOrEmpty(dataIn)) return string.Empty;

        var strDataOut = new System.Text.StringBuilder();
        int keyLen = CodeKey.Length;
        int dataLen = dataIn.Length;

        for (int i = 0; i < dataLen / 2; i++)
        {
            // arkdata1 = i + 1

            // intXOrValue1 = Val("&H" & (Mid$(DataIn, (2 * arkdata1) - 1, 2)))
            string hexPair = dataIn.Substring(i * 2, 2);
            int value1 = Convert.ToInt32(hexPair, 16);

            // intXOrValue2 = Asc(Mid$(CodeKey, ((arkdata1 Mod Len(CodeKey)) + 1), 1))
            // Same key logic as Encrypt
            int keyIndex = ((i + 1) % keyLen);
            int value2 = (int)CodeKey[keyIndex];

            char decodedChar = (char)(value1 ^ value2);
            strDataOut.Append(decodedChar);
        }

        return strDataOut.ToString();
    }
}
