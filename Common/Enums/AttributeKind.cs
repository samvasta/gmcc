namespace Common.Enums
{

    public enum AttributeKind
    {
        
        ///<summary>
        /// Used for attributes that describe a creature's basic ability. Ex. strength, intelligence
        ///</summary>
        Ability = 0,
        
        ///<summary>
        /// Used for attributes where the value is some function of a specific ability
        ///</summary>
        AbilitySkill = 1,
        
        ///<summary>
        /// Used for attributes that may be changed on the fly, such has health or stamina
        ///</summary>
        Counter = 2,
        
        ///<summary>
        /// Used for miscellaneous attributes
        ///</summary>
        Other = 3
    }

}