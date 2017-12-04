public static class DataTypeExtensions {
    /// <summary>
    /// To Int
    /// </summary>
    /// <param name="str"></param>
    /// <param name="defaultt"></param>
    /// <returns></returns>
    public static int ToInt(this string str, int defaultt = 0) {
        if (int.TryParse(str, out int n)) {
            return n;
        } else {
            return defaultt;
        }
    }
}