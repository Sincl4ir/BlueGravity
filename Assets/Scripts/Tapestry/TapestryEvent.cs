/// <summary>
/// An event that stores a list of subscribers. 
/// </summary>
namespace BlueGravity.Tapestry
{
    public class TapestryEvent<T>
    {
        System.Action<T> repeatUseDelagate;
        System.Action<T> singleUseDelegate;

        public void Invoke(T inParams)
        {
            if (repeatUseDelagate != null)
            {
                repeatUseDelagate(inParams);
            }
            if (singleUseDelegate != null)
            {
                singleUseDelegate(inParams);
                singleUseDelegate = null;
            }
        }

        public void SubscribeMethod(System.Action<T> inAction, bool isSingleUse = false)
        {
            if (isSingleUse)
            {
                singleUseDelegate += inAction;
            }
            else
            {
                repeatUseDelagate += inAction;
            }
        }

        public void RemoveRepeatingMethod(System.Action<T> inAction)
        {
            repeatUseDelagate -= inAction;
        }

        public void RemoveOneShotMethod(System.Action<T> inAction)
        {
            singleUseDelegate -= inAction;
        }

        public int GetInvocationCount()
        {
            return ((repeatUseDelagate == null ? 0 : repeatUseDelagate.GetInvocationList().Length) + (singleUseDelegate == null ? 0 : singleUseDelegate.GetInvocationList().Length));
        }
    }

    public class TapestryEvent<T1, T2>
    {
        System.Action<T1, T2> repeatUseDelagate;
        System.Action<T1, T2> singleUseDelagate;

        public void Invoke(T1 inParams1, T2 inParams2)
        {
            if (repeatUseDelagate != null)
            {
                repeatUseDelagate(inParams1, inParams2);
            }
            if (singleUseDelagate != null)
            {
                singleUseDelagate(inParams1, inParams2);
                singleUseDelagate = null;
            }
        }

        public void SubscribeMethod(System.Action<T1, T2> inAction, bool isSingleUse)
        {
            if (isSingleUse)
            {
                singleUseDelagate += inAction;
            }
            else
            {
                repeatUseDelagate += inAction;
            }
        }

        public void RemoveRepeatingMethod(System.Action<T1, T2> inAction)
        {
            repeatUseDelagate -= inAction;
        }

        public void RemoveOneShotMethod(System.Action<T1, T2> inAction)
        {
            singleUseDelagate -= inAction;
        }

        public int GetInvocationCount()
        {
            return ((repeatUseDelagate == null ? 0 : repeatUseDelagate.GetInvocationList().Length) + (singleUseDelagate == null ? 0 : singleUseDelagate.GetInvocationList().Length));
        }
    }

    public class TapestryEvent<T1, T2, T3>
    {
        System.Action<T1, T2, T3> repeatUseDelegate;
        System.Action<T1, T2, T3> singleUseDelegate;

        public void Invoke(T1 inParams1, T2 inParams2, T3 inParams3)
        {
            if (repeatUseDelegate != null)
            {
                repeatUseDelegate(inParams1, inParams2, inParams3);
            }
            if (singleUseDelegate != null)
            {
                singleUseDelegate(inParams1, inParams2, inParams3);
                singleUseDelegate = null;
            }
        }

        public void SubscribeMethod(System.Action<T1, T2, T3> inAction, bool isSingleUse)
        {
            if (isSingleUse)
            {
                singleUseDelegate += inAction;
            }
            else
            {
                repeatUseDelegate += inAction;
            }
        }

        public void RemoveRepeatingMethod(System.Action<T1, T2, T3> inAction)
        {
            repeatUseDelegate -= inAction;
        }

        public void RemoveOneShotMethod(System.Action<T1, T2, T3> inAction)
        {
            singleUseDelegate -= inAction;
        }

        public int GetInvocationCount()
        {
            return ((repeatUseDelegate == null ? 0 : repeatUseDelegate.GetInvocationList().Length) + (singleUseDelegate == null ? 0 : singleUseDelegate.GetInvocationList().Length));
        }
    }

    public class TapestryEvent<T1, T2, T3, T4, T5>
    {
        System.Action<T1, T2, T3, T4, T5> repeatUseDelegate;
        System.Action<T1, T2, T3, T4, T5> singleUseDelegate;

        public void Invoke(T1 inParams1, T2 inParams2, T3 inParams3, T4 inParams4, T5 inParam5)
        {
            if (repeatUseDelegate != null)
            {
                repeatUseDelegate(inParams1, inParams2, inParams3, inParams4, inParam5);
            }
            if (singleUseDelegate != null)
            {
                singleUseDelegate(inParams1, inParams2, inParams3, inParams4, inParam5);
                singleUseDelegate = null;
            }
        }

        public void SubscribeMethod(System.Action<T1, T2, T3, T4, T5> inAction, bool isSingleUse)
        {
            if (isSingleUse)
            {
                singleUseDelegate += inAction;
            }
            else
            {
                repeatUseDelegate += inAction;
            }
        }

        public void RemoveRepeatingMethod(System.Action<T1, T2, T3, T4, T5> inAction)
        {
            repeatUseDelegate -= inAction;
        }

        public void RemoveOneShotMethod(System.Action<T1, T2, T3, T4, T5> inAction)
        {
            singleUseDelegate -= inAction;
        }

        public int GetInvocationCount()
        {
            return ((repeatUseDelegate == null ? 0 : repeatUseDelegate.GetInvocationList().Length) + (singleUseDelegate == null ? 0 : singleUseDelegate.GetInvocationList().Length));
        }
    }

    public class TapestryEvent
    {
        System.Action repeatUseDelegate;
        System.Action singleUseDelegate;

        public void Invoke()
        {
            if (repeatUseDelegate != null)
            {
                repeatUseDelegate();
            }
            if (singleUseDelegate != null)
            {
                singleUseDelegate();
                singleUseDelegate = null;
            }
        }

        public void SubscribeMethod(System.Action inAction, bool isSingleUse)
        {
            if (isSingleUse)
            {
                singleUseDelegate += inAction;
            }
            else
            {
                repeatUseDelegate += inAction;
            }
        }

        public void RemoveRepeatingMethod(System.Action inAction)
        {
            repeatUseDelegate -= inAction;
        }

        public void RemoveOneShotMethod(System.Action inAction)
        {
            singleUseDelegate -= inAction;
        }


        public int GetInvocationCount()
        {
            return ((repeatUseDelegate == null ? 0 : repeatUseDelegate.GetInvocationList().Length) + (singleUseDelegate == null ? 0 : singleUseDelegate.GetInvocationList().Length));
        }
    }
}
//EOF.