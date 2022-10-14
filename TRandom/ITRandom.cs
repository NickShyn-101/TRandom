namespace TRandom
{

    /// <summary>
    /// <list type="bullet"> 
    /// <item>TRandomNumber</item>
    /// <item>TRandomString</item>
    /// <item>TRandomEnum</item>
    /// </list>    
    /// <c>some text</c>
    /// <para>some otehr text</para>
    /// <see cref="TRandom.Core.TRandomOptions"/>
    /// <seealso cref="TRandom.Types.RandomNumber{T}"/>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// 
    public interface ITRandom<T>
    {
        T Next();
    }

}