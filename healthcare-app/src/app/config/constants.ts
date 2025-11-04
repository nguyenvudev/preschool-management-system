export const GENDER_OPTIONS = [
    { value: 'male', label: 'Nam' },
    { value: 'female', label: 'Nữ' },
  ] as const;
  
  export const CLASS_STATUS = {
    ACTIVE: 'active',
    INACTIVE: 'inactive',
    FULL: 'full',
  } as const;
  
  export const ATTENDANCE_STATUS = {
    PRESENT: 'present',
    ABSENT: 'absent',
    LATE: 'late',
    SICK: 'sick',
    EXCUSED: 'excused',
  } as const;
  
  export const MEAL_TYPES = {
    BREAKFAST: 'breakfast',
    LUNCH: 'lunch',
    SNACK: 'snack',
    DINNER: 'dinner',
  } as const;
  
  export const HEALTH_STATUS = {
    EXCELLENT: 'excellent',
    GOOD: 'good',
    FAIR: 'fair',
    POOR: 'poor',
  } as const;
  
  export const BLOOD_TYPES = ['A+', 'A-', 'B+', 'B-', 'AB+', 'AB-', 'O+', 'O-'] as const;
  
  export const ALLERGY_TYPES = [
    'Sữa',
    'Trứng',
    'Đậu phộng',
    'Hạt cây',
    'Cá',
    'Hải sản',
    'Lúa mì',
    'Đậu nành',
    'Thuốc',
    'Khác'
  ] as const;
  
  export const VACCINE_STATUS = {
    COMPLETED: 'completed',
    PENDING: 'pending',
    OVERDUE: 'overdue',
    EXEMPT: 'exempt',
  } as const;