namespace LovePlatform.Domain.Models
{
    public partial class BloodPressure
    {
        /// <summary>
        /// 血压是否正常
        /// </summary>
        public bool IsNormal
        {
            get
            {
                return DiastolicPressureIsNormal && HeartRateIsNormal && SystolicPressureIsNormal &&
                  ((SystolicPressure - DiastolicPressure) >= 20) && ((SystolicPressure - DiastolicPressure) <= 60);
            }
        }
    }
}
