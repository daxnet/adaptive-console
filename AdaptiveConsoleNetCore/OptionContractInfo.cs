/* ----------------------------------------------------------------------------
 * AdaptiveConsole - A flexable console application framework.
 * Copyright (C) 2007-2008 SunnyChen.ORG, all rights reserved.
 * 
 * Author        : Sunny Chen
 * Company       : SunnyChen.ORG, http://www.sunnychen.org
 * Version       : 1.0
 * Date          : 9/16/2008
 * 
 * 
 * UPDATE HISTORY
 * ----------------------------------------------------------------------------
 * DATE          DESCRIPTION                            VERSION         UPDATED_BY
 * 9/16/2008     Created                                3.5.3182.35766  Sunny Chen
 * ---------------------------------------------------------------------------- */


namespace AdaptiveConsole
{
    /// <summary>
    /// Information carrier which contains the information about an option contract
    /// and its attribute.
    /// </summary>
    internal class OptionContractInfo
    {
        #region Public Properties
        /// <summary>
        /// Gets or sets the option contract.
        /// </summary>
        internal OptionContractBase OptionContract { get; set; }
        /// <summary>
        /// Gets or sets the attribute of the option contract.
        /// </summary>
        internal OptionContractAttribute ContractAttribute { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes the information carrier with no parameter.
        /// </summary>
        internal OptionContractInfo() { }
        /// <summary>
        /// Initializes the information carrier with option contract and its attribute.
        /// </summary>
        /// <param name="optionContract">Option contract.</param>
        /// <param name="contractAttribute">The attribute of the option contract.</param>
        internal OptionContractInfo(OptionContractBase optionContract, OptionContractAttribute contractAttribute)
        {
            this.OptionContract = optionContract;
            this.ContractAttribute = contractAttribute;
        }
        #endregion
    }
}
