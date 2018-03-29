using System;

namespace AdaptiveConsoleCore
{
    /// <summary>
    /// Type of the contract.
    /// </summary>
    public enum ContractType
    {
        /// <summary>
        /// Indicates that the contract will match
        /// the optional command line argument.
        /// </summary>
        Patternized,
        /// <summary>
        /// Indicates that the contract will match
        /// the exact command line argument.
        /// </summary>
        Exact,
        /// <summary>
        /// Indicates that the contract will match
        /// the command without any argument.
        /// </summary>
        None,
        /// <summary>
        /// Indicates that the contract will match
        /// the command in which the arguments are
        /// all Parameter.
        /// </summary>
        Free
    }
}
