namespace ReHub.Utilities.Encryption
{
    /// <summary>
    /// Encryption algorithm types.
    /// </summary>
    public enum EncryptionAlgorithm
    {
        /// <summary>
        /// Specifies the Advanced Encryption Standard (AES) symmetric encryption algorithm.
        /// </summary>
        Aes,

        /// <summary>
        /// Specifies the Data Encryption Standard (DES) symmetric encryption algorithm.
        /// </summary>
        Des,

        /// <summary>
        /// Specifies the RC2 symmetric encryption algorithm.
        /// </summary>
        Rc2,

        /// <summary>
        /// Specifies the Rijndael symmetric encryption algorithm.
        /// </summary>
        Rijndael,

        /// <summary>
        /// Specifies the TripleDES symmetric encryption algorithm.
        /// </summary>
        TripleDes
    }
}
