﻿using System;
using UnityEngine;

namespace Gameframe.InfoTables
{
  /// <summary>
  /// InfoId converts a human readable string to a numerical id
  /// Generally to be used as a key to associate data with assets and static data
  /// </summary>
  [Serializable]
  public class InfoId : ISerializationCallbackReceiver
  {
    
    private static InfoId _invalid = new InfoId();
    
    [SerializeField] 
    private string key = string.Empty;
    
    [SerializeField, HideInInspector] 
    private int id = 0;
    
    /// <summary>
    /// The invalid InfoId with a Value of 0
    /// </summary>
    public static InfoId Invalid => _invalid;

    /// <summary>
    /// The default constructor will create an invlaid InfoId by default 
    /// </summary>
    private InfoId()
    {
    }

    /// <summary>
    /// Construct a new InfoId
    /// </summary>
    /// <param name="key">String used to generate the hash integer Value</param>
    public InfoId(string key)
    {
      this.key = key;
      id = key.GetHashCode();
    }

    /// <summary>
    /// Key is the string hashed to generate the integer id Value
    /// </summary>
    public string Key => key;

    /// <summary>
    /// Value is an integer equal to the hashed value of the Key
    /// </summary>
    public int Value => id;

    /// <summary>
    /// Checks if this is a valid game id 
    /// </summary>
    /// <returns>True when the Value property is non-zero</returns>
    public bool IsValid()
    {
      return id != 0;
    }

    #region ISerializationCallbackReceiver

    /// <inheritdoc/>
    public void OnBeforeSerialize()
    {
      id = string.IsNullOrEmpty(key) ? 0 : GetId(key);
    }

    /// <inheritdoc/>
    public void OnAfterDeserialize()
    {
      id = string.IsNullOrEmpty(key) ? 0 : GetId(key);
    }

    #endregion

    /// <summary>
    /// Overridden to compare only the value property
    /// </summary>
    /// <param name="obj">Object to be compared to</param>
    /// <returns></returns>
    public override bool Equals(object obj)
    {
      if (!(obj is InfoId))
      {
        return false;
      }
      var other = (InfoId) obj;
      return other.Value == Value;
    }

    /// <summary>
    /// Returns the hash code of the Key
    /// </summary>
    /// <returns>Same integer as the Value property</returns>
    public override int GetHashCode()
    {
      return Value;
    }

    /// <summary>
    /// Calculates a stable hash code from the given string
    /// </summary>
    /// <param name="str">String to hash</param>
    /// <returns>integer hash of the string parameter</returns>
    public static int GetId(string str)
    {
      unchecked
      {
        int hash1 = 5381;
        int hash2 = hash1;

        for (int i = 0; i < str.Length && str[i] != '\0'; i += 2)
        {
          hash1 = ((hash1 << 5) + hash1) ^ str[i];
          if (i == str.Length - 1 || str[i + 1] == '\0')
            break;
          hash2 = ((hash2 << 5) + hash2) ^ str[i + 1];
        }

        return hash1 + (hash2 * 1566083941);
      }
    }

    /// <summary>
    /// Formats InfoId data in a debug log friendly way
    /// </summary>
    /// <returns>String with the format "InfoId({Key}:{Value})</returns>
    public override string ToString()
    {
      return $"InfoId({Key}:{Value})";
    }
    
  }
}