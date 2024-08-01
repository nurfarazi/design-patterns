namespace SOLID_SRP;

public class JournalExtendedPersistence
{
    public static void SaveToFile(Journal journal, string filename, bool overwrite = false)
    {
        if (!overwrite && File.Exists(filename))
            return;
        File.WriteAllText(filename, journal.ToString());
    }
}