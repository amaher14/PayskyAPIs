namespace Core.Constants
{
    public static class ValidationErrorCodes 
    { 
        //Model Validations
        public static int Mandatory => 1001;
        public static int Required => 1001;
        public static int NotIdentical => 1002;
        public static int NotCorrectLength => 1003; 
        public static int CanNotDelete => 1004; 
        //Syntax Validation
        public static int MustBeInEnglish => 2001;
        public static int NotValidEmailAddress => 2002; 
        public static int NotAllowedExtension => 2003;
        public static int NotValidFormat => 2003;
        public static int NotValidDimensions => 2004;
        public static int NotValidDataType => 2005;
        //Performance
        public static int Unauthorized => 9100;
        public static int Forbidden => 9101; 
        //Existing
        public static int NotExisting => 3001;
        public static int EmailAddressDuplication => 3002; 
        public static int VerificationCodeExpired => 3003; 
        public static int RefreshTokenNotValid => 3004;
        public static int AlreadyExists => 3005;
        public static int RelatedItems => 3006;
        public static int AlreadyAssigned => 3007;
        public static int ActionNotAllowed => 3009;
        public static int InvalidOperation => 3017; 
        public static int ItemUsed => 3018; public static int Cycle => 3019; 
    } 
}