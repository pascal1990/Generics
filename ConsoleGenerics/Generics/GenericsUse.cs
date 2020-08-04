using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;

public static class GenericsUse
{
    public static void Enregister<T>(List<T> data, string chemin) where T : class, new()
    {
        List<string> lignes = new List<string>();
        T t = new T();
        var proprietes = t.GetType().GetProperties();
        StringBuilder ligne = new StringBuilder();

        foreach (var propriete in proprietes)
        {
            ligne.Append(propriete.Name);
            ligne.Append(",");
        }



        lignes.Add(ligne.ToString().Substring(0, ligne.Length - 1));



        foreach (T elt in data)
        {
            ligne = new StringBuilder();
            foreach (var propriete in proprietes)
            {
                ligne.Append(propriete.GetValue(elt).ToString());
                ligne.Append(",");
            }
            lignes.Add(ligne.ToString().Substring(0, ligne.Length - 1));
        }

        System.IO.File.WriteAllLines(chemin, lignes);

    }

    public static List<T> Charge<T>(string chemin) where T : class, new()
    {
        List<T> output = new List<T>();
        T t = new T();
        List<string> lignes = new List<string>();

        var proprietes = t.GetType().GetProperties();

        var dataFile = System.IO.File.ReadAllLines(chemin);

        foreach (string elt in dataFile)
        {
            lignes.Add(elt);
        }

        var entete = lignes[0].Split(','); // entete du fichier CSV
        lignes.RemoveAt(0); // supprimer l'entete

        foreach (string elt in lignes)
        {
            t = new T();
            var vals = elt.Split(',');

            for (int i = 0; i < entete.Length; i++)
            {
                foreach (var propriete in proprietes)
                {
                    if (propriete.Name == entete[i])
                    {
                        propriete.SetValue(t, Convert.ChangeType(vals[i], propriete.PropertyType));
                    }
                }
            }

            output.Add(t);
        }



        return output;

    }


    public static List<T> Charge_1<T>(string chemin) where T : class, new()
    {
        List<T> output = new List<T>();
        T entry = new T();

        var proprietes = entry.GetType().GetProperties();

        List<string> lignes = new List<string>();

        var dataFile = System.IO.File.ReadAllLines(chemin);

        foreach(string elt in dataFile)
        {
            lignes.Add(elt);
        }

        var header = lignes[0].Split(',');
        lignes.RemoveAt(0);

        foreach(string elt in lignes)
        {
            var vals = elt.Split(',');
            entry = new T();
            for(int i=0; i < header.Length; i++)
            {
                foreach(var propriete in proprietes)
                {
                    if(propriete.Name == header[i])
                    {
                        propriete.SetValue(entry, Convert.ChangeType(vals[i], propriete.GetType()));
                    }
                }
            }

            output.Add(entry);
        }

        return output;

    }
}

