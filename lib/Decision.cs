namespace d9.lcm;
public enum Decision
{
    LockedIn    =  5,
    Active      =  4,
    Deferred    =  3,
    Pending     =  2,
    Poll        =  1,
    Considering =  0,
    Rejected    = -1
}