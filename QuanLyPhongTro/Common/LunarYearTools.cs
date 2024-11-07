using System;

namespace MyWork
{
    public static class LunarYearTools
    {
        #region Các hàm tính toán chung
        private const double PI = Math.PI;

        private static long INT(double d)
        {
            return (long)Math.Floor(d);
        }

        private static long jdFromDate(int dd, int mm, int yy)
        {
            long a, y, m, jd;
            a = INT((14 - mm) / 12);
            y = yy + 4800 - a;
            m = mm + 12 * a - 3;
            jd = dd + INT((153 * m + 2) / 5) + 365 * y + INT(y / 4) - INT(y / 100) + INT(y / 400) - 32045;
            if (jd < 2299161)
            {
                jd = dd + INT((153 * m + 2) / 5) + 365 * y + INT(y / 4) - 32083;
            }
            return jd;
        }

        private static DateTime jdToDate(long jd)
        {
            long a, b, c, d, e, m, day, month, year;
            if (jd > 2299160)
            {
                a = jd + 32044;
                b = INT((4 * a + 3) / 146097);
                c = a - INT((b * 146097) / 4);
            }
            else
            {
                b = 0;
                c = jd + 32082;
            }
            d = INT((4 * c + 3) / 1461);
            e = c - INT((1461 * d) / 4);
            m = INT((5 * e + 2) / 153);
            day = e - INT((153 * m + 2) / 5) + 1;
            month = m + 3 - 12 * INT(m / 10);
            year = b * 100 + d - 4800 + INT(m / 10);
            return new DateTime((int)year, (int)month, (int)day);
        }

        private static long NewMoon(long k)
        {
            double T, T2, T3, dr, Jd1, M, Mpr, F, C1, deltat, JdNew;
            T = k / 1236.85;
            T2 = T * T;
            T3 = T2 * T;
            dr = PI / 180;
            Jd1 = 2415020.75933 + 29.53058868 * k + 0.0001178 * T2 - 0.000000155 * T3;
            Jd1 += 0.00033 * Math.Sin((166.56 + 132.87 * T - 0.009173 * T2) * dr);
            M = 359.2242 + 29.10535608 * k - 0.0000333 * T2 - 0.00000347 * T3;
            Mpr = 306.0253 + 385.81691806 * k + 0.0107306 * T2 + 0.00001236 * T3;
            F = 21.2964 + 390.67050646 * k - 0.0016528 * T2 - 0.00000239 * T3;
            C1 = (0.1734 - 0.000393 * T) * Math.Sin(M * dr) + 0.0021 * Math.Sin(2 * dr * M);
            C1 += -0.4068 * Math.Sin(Mpr * dr) + 0.0161 * Math.Sin(dr * 2 * Mpr);
            C1 += -0.0004 * Math.Sin(dr * 3 * Mpr);
            C1 += 0.0104 * Math.Sin(dr * 2 * F) - 0.0051 * Math.Sin(dr * (M + Mpr));
            C1 += -0.0074 * Math.Sin(dr * (M - Mpr)) + 0.0004 * Math.Sin(dr * (2 * F + M));
            C1 += -0.0004 * Math.Sin(dr * (2 * F - M)) - 0.0006 * Math.Sin(dr * (2 * F + Mpr));
            C1 += 0.0010 * Math.Sin(dr * (2 * F - Mpr)) + 0.0005 * Math.Sin(dr * (2 * Mpr + M));
            deltat = T < -11 ? 0.001 + 0.000839 * T + 0.0002261 * T2 - 0.00000845 * T3 - 0.000000081 * T * T3 : -0.000278 + 0.000265 * T + 0.000262 * T2;
            JdNew = Jd1 + C1 - deltat;
            return (long)Math.Round(JdNew);
        }

        private static double SunLongitude(double jdn)
        {
            double T, T2, dr, M, L0, DL, L;
            T = (jdn - 2451545.0) / 36525;
            T2 = T * T;
            dr = PI / 180;
            M = 357.52910 + 35999.05030 * T - 0.0001559 * T2 - 0.00000048 * T * T2;
            L0 = 280.46645 + 36000.76983 * T + 0.0003032 * T2;
            DL = (1.914600 - 0.004817 * T - 0.000014 * T2) * Math.Sin(dr * M);
            DL += (0.019993 - 0.000101 * T) * Math.Sin(dr * 2 * M) + 0.000290 * Math.Sin(dr * 3 * M);
            L = L0 + DL;
            L = L * dr;
            L = L - PI * 2 * (INT(L / (PI * 2)));
            return L;
        }

        private static long getSunLongitude(long dayNumber, int timeZone)
        {
            return INT(SunLongitude(dayNumber - 0.5 - timeZone / 24) / PI * 6);
        }
        private static long getNewMoonDay(long k, int timeZone)
        {
            return (long)Math.Round(NewMoon(k) + 0.5 + timeZone / 24.0);
        }

        private static long getLunarMonth11(int yy, int timeZone)
        {
            long k, off, nm, sunLong;
            off = jdFromDate(31, 12, yy) - 2415021;
            k = INT(off / 29.530588853);
            nm = getNewMoonDay(k, timeZone);
            sunLong = getSunLongitude(nm, timeZone);
            if (sunLong >= 9)
            {
                nm = getNewMoonDay(k - 1, timeZone);
            }
            return nm;
        }

        private static long getLeapMonthOffset(long a11, int timeZone)
        {
            long k, last, arc, i;
            k = INT((a11 - 2415021) / 29.530588853 + 0.5);
            last = 0;
            i = 1;
            arc = getSunLongitude(getNewMoonDay(k + i, timeZone), timeZone);
            do
            {
                last = arc;
                i++;
                arc = getSunLongitude(getNewMoonDay(k + i, timeZone), timeZone);
            } while (arc != last && i < 14);
            return i - 1;
        }
        #endregion

        #region Các hàm chuyển đổi
        public static LunarDate SolarToLunar(DateTime date)
        {
            return SolarToLunar(date, 7);
        }

        public static LunarDate SolarToLunar(DateTime date, int timeZone)
        {
            long k, dayNumber, monthStart, a11, b11, lunarDay, lunarMonth, lunarYear, diff, leapMonthDiff;
            bool lunarLeap;

            dayNumber = jdFromDate(date.Day, date.Month, date.Year);
            k = INT((dayNumber - 2415021) / 29.530588853);
            monthStart = getNewMoonDay(k + 1, timeZone);
            if (monthStart > dayNumber)
            {
                monthStart = getNewMoonDay(k, timeZone);
            }
            a11 = getLunarMonth11(date.Year, timeZone);
            b11 = a11;
            if (a11 > monthStart)
            {
                lunarYear = date.Year;
                a11 = getLunarMonth11(date.Year - 1, timeZone);
            }
            else
            {
                lunarYear = date.Year;
                b11 = getLunarMonth11(date.Year + 1, timeZone);
            }
            lunarDay = dayNumber - monthStart + 1;
            diff = INT((monthStart - a11) / 29);
            lunarLeap = false;
            lunarMonth = diff + 11;
            if (b11 - a11 > 365)
            {
                leapMonthDiff = getLeapMonthOffset(a11, timeZone);
                if (diff >= leapMonthDiff)
                {
                    lunarMonth = diff + 10;
                    if (diff == leapMonthDiff)
                    {
                        lunarLeap = true;
                    }
                }
            }
            if (lunarMonth > 12)
            {
                lunarMonth = lunarMonth - 12;
            }
            if (lunarMonth >= 11 && diff < 4)
            {
                lunarYear -= 1;
            }
            return new LunarDate((int)lunarDay, (int)lunarMonth, (int)lunarYear, lunarLeap);
        }

        public static DateTime LunarToSolar(LunarDate ld)
        {
            return LunarToSolar(ld, 7);
        }

        public static DateTime LunarToSolar(LunarDate ld, int timeZone)
        {
            long k, a11, b11, off, leapOff, leapMonth, monthStart;
            if (ld.Month < 11)
            {
                a11 = getLunarMonth11(ld.Year - 1, timeZone);
                b11 = getLunarMonth11(ld.Year, timeZone);
            }
            else
            {
                a11 = getLunarMonth11(ld.Year, timeZone);
                b11 = getLunarMonth11(ld.Year + 1, timeZone);
            }
            k = INT(0.5 + (a11 - 2415021) / 29.530588853);
            off = ld.Month - 11;
            if (off < 0)
            {
                off += 12;
            }
            if (b11 - a11 > 365)
            {
                leapOff = getLeapMonthOffset(a11, timeZone);
                leapMonth = leapOff - 2;
                if (leapMonth < 0)
                {
                    leapMonth += 12;
                }
                if (ld.IsLeapYear && ld.Month != leapMonth)
                {
                    return DateTime.MinValue;
                }
                else if (ld.IsLeapYear || off >= leapOff)
                {
                    off += 1;
                }
            }
            monthStart = getNewMoonDay(k + off, timeZone);
            return jdToDate(monthStart + ld.Day - 1);
        }
        #endregion

        public static bool KTNamNhuan(int year)
        {
            bool isLeap = false;
            if (year % 4 == 0)
            {
                if (year % 100 == 0)
                {
                    if (year % 400 == 0)
                    {
                        isLeap = true;
                    }
                    else
                    {
                        isLeap = false;
                    }
                }
                else
                {
                    isLeap = true;
                }
            }
            else
            {
                isLeap = false;
            }
            return isLeap;
        }
    }
}

public class LunarDate
{
    public int Day { get; set; }
    public int Month { get; set; }
    public int Year { get; set; }
    public bool IsLeapYear { get; set; }

    public LunarDate() { }

    public LunarDate(int day, int month, int year, bool leap)
    {
        Day = day;
        Month = month;
        Year = year;
        IsLeapYear = leap;
    }
}

