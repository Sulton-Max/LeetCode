using System;

namespace RegularExpMatching_10
{
    public class Solution
    {
        public bool IsMatch(string s, string p)
        {
            bool CheckValidity(int index)
            {
                bool valid = true;
                if (index == p.Length) 
                    return true;
                do
                {
                    if (index + 1 < p.Length)
                    {
                        if (p[index] != '*')
                            valid = (p[index + 1] == '*');
                    }
                    else
                    {
                        if (p[index] != '*' && index + 1 == p.Length)
                            valid = false;
                    }

                    if (!valid)
                        break;
                } while (Increase(ref index, p.Length));
                return valid;
            }

            bool Increase(ref int index, int length) => ((index + 1 < length) ? ++index < length : false);

            bool IsMatch(char sChar, char pChar) => (pChar == '.') ? true : (sChar == pChar);

            bool HasShouldMet(int index, ref char shouldMet)
            {
                if (index == p.Length)
                    return false;

                do
                {
                    if (index + 1 == p.Length && p[index] != '*')
                    {
                        shouldMet = p[index];
                        return true;
                    }

                    if (index + 1 < p.Length && p[index] != '*' && p[index + 1] != '*')
                    {
                        shouldMet = p[index];
                        return true;
                    }
                } while (++index < p.Length);
                return false;
            }

            if (p.Length == 1)
                return (p[0] == '.')
                    ? (s.Length == 1)
                    : (s.Length == 1 && s[0] == p[0]);

            int indexS = 0, indexP = 0;
            bool isMatch = true;
            char previous = ' ';
            char shouldMet = ' ';

            while (true)
            {
                // Check for cycling char
                if (p[indexP] == '*')
                {
                    // If s has no length
                    if(indexS == s.Length)
                    {
                        return CheckValidity(indexP);
                    }

                    // Check char previous char match
                    if (IsMatch(s[indexS], previous))
                    {
                        // Check for should met char 
                        if (HasShouldMet(indexP, ref shouldMet))
                        {
                            // If Match then switch from cycling char
                            if (IsMatch(s[indexS], shouldMet))
                            {
                                // Check for should met Char for next char
                                if (indexS + 1 < s.Length && IsMatch(s[indexS + 1], shouldMet))
                                {
                                    // Switch to check next chars for cycling char, as there other ones, should met can be met later 
                                    Increase(ref indexS, s.Length);
                                    continue;
                                }
                                else // There no other should met chars, we should switch now
                                {
                                    // Switch to should met char and continue
                                    Increase(ref indexP, p.Length);
                                    continue;
                                }
                            }
                            else // Simply switch to next s char
                            {
                                if (!Increase(ref indexS, s.Length))
                                    return false;
                                else
                                    continue;
                            }
                        }
                        else // p Does not have Should Met char and Match to Cycling char
                        {
                            if (!Increase(ref indexS, s.Length))
                                return true;
                            else
                                continue;
                        }
                    }
                    else // Cycling char does not match so switch to next p char
                    {
                        if (!Increase(ref indexP, p.Length))
                        {
                            if (indexS < s.Length)
                                return false;
                            else
                                return true;
                        }
                        else
                            continue;
                    }
                }
                else
                {
                    if (indexP + 1 < p.Length && p[indexP + 1] == '*')
                    {
                        previous = p[indexP++];
                        continue;
                    }

                    // If s has no length
                    if(indexS == s.Length)
                    {
                        return CheckValidity(indexP);
                    }

                    if (IsMatch(s[indexS], p[indexP]))
                    {
                        if (Increase(ref indexS, s.Length))
                        {
                            if (Increase(ref indexP, p.Length))
                                continue;
                            else
                                return false;
                        }
                        else
                            return CheckValidity(indexP + 1);
                    }
                    else
                        return false;
                }
            }
        }
    }
}
