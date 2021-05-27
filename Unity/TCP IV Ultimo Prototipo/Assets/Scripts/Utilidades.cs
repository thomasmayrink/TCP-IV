using System.Collections.Generic;
using UnityEngine;

public static class Utilidades
{
    public static void SortearLista<T>(this IList<T> ts)
    {
        var count = ts.Count;
        var last = count - 1;
        for (var i = 0; i < last; i++)
        {
            var r = Random.Range(i, count);
            var tmp = ts[i];
            ts[i] = ts[r];
            ts[r] = tmp;
        }
    }

    public static string DebugComCor(string txt, string cor)
    {
        return "<color=" + cor + ">" + txt + "</color>";
    }
}
