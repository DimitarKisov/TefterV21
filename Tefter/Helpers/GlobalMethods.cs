namespace Tefter.Helpers
{
    public static class GlobalMethods
    {
        public static string CapitalizeFirstLetter(string str)
        {
            return char.ToUpper(str[0]) + str.Substring(1).ToLower();
        }

        public static string CapitalizeOwnerName(string owner)
        {
            var ownerSplited = owner.Split();

            return ownerSplited.Length == 1
                ? char.ToUpper(ownerSplited[0][0]) + ownerSplited[0].Substring(1).ToLower() : ownerSplited.Length == 2
                ? char.ToUpper(ownerSplited[0][0]) + ownerSplited[0].Substring(1).ToLower() + " " + char.ToUpper(ownerSplited[1][0]) + ownerSplited[1].Substring(1).ToLower() : ownerSplited.Length == 3
                ? char.ToUpper(ownerSplited[0][0]) + ownerSplited[0].Substring(1).ToLower() + " " + char.ToUpper(ownerSplited[1][0]) + ownerSplited[1].Substring(1).ToLower() + " " + char.ToUpper(ownerSplited[2][0]) + ownerSplited[2].Substring(1).ToLower() : owner;
        }
    }
}
