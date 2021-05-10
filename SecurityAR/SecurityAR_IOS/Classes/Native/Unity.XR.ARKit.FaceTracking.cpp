#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif


#include <cstring>
#include <string.h>
#include <stdio.h>
#include <cmath>
#include <limits>
#include <assert.h>
#include <stdint.h>

#include "codegen/il2cpp-codegen.h"
#include "il2cpp-object-internals.h"


// System.Char[]
struct CharU5BU5D_t4CC6ABF0AD71BEC97E3C2F1E9C5677E46D3A75C2;
// System.Reflection.Binder
struct Binder_t4D5CB06963501D32847C057B57157D6DC49CA759;
// System.Reflection.MemberFilter
struct MemberFilter_t25C1BD92C42BE94426E300787C13C452CB89B381;
// System.String
struct String_t;
// System.Type
struct Type_t;
// System.Type[]
struct TypeU5BU5D_t7FE623A666B49176DE123306221193E888A12F5F;
// System.Void
struct Void_t22962CB4C05B1D89B55A6E1139F0E87A90987017;
// UnityEngine.ISubsystemDescriptor
struct ISubsystemDescriptor_t5BCD578E4BAD3A0C1DF6C5654720FE7D4420605B;
// UnityEngine.XR.ARKit.ARKitFaceSubsystem
struct ARKitFaceSubsystem_t24E01CF6C590EFAC9B51F7B1D341C646A69E9CD9;
// UnityEngine.XR.ARKit.ARKitFaceSubsystem/Provider
struct Provider_t1A0EF7D1C90CB7506DABB17AA054D7FE2B5493F2;
// UnityEngine.XR.ARSubsystems.XRFaceSubsystem
struct XRFaceSubsystem_t1EED929C2E01770DF939C53497D9DFA37A105D58;
// UnityEngine.XR.ARSubsystems.XRFaceSubsystem/IProvider
struct IProvider_t7B064D81E20EE0044470073AC7EABCD30910FEFB;

IL2CPP_EXTERN_C RuntimeClass* Provider_t1A0EF7D1C90CB7506DABB17AA054D7FE2B5493F2_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C RuntimeClass* Type_t_il2cpp_TypeInfo_var;
IL2CPP_EXTERN_C String_t* _stringLiteralB658968A18F22D3650C28036F22B7192196C1DEC;
IL2CPP_EXTERN_C const RuntimeType* ARKitFaceSubsystem_t24E01CF6C590EFAC9B51F7B1D341C646A69E9CD9_0_0_0_var;
IL2CPP_EXTERN_C const uint32_t ARKitFaceSubsystem_CreateProvider_m778057F5740ACFB678634459668EFB28B89528C0_MetadataUsageId;
IL2CPP_EXTERN_C const uint32_t ARKitFaceSubsystem_RegisterDescriptor_mC00841747E3532C2A69720ECBA2EA399C657E111_MetadataUsageId;


IL2CPP_EXTERN_C_BEGIN
IL2CPP_EXTERN_C_END

#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// <Module>
struct  U3CModuleU3E_t1CF7C307ED677A54A6DD437A7514266A3972F693 
{
public:

public:
};


// System.Object

struct Il2CppArrayBounds;

// System.Array


// System.Reflection.MemberInfo
struct  MemberInfo_t  : public RuntimeObject
{
public:

public:
};


// System.String
struct  String_t  : public RuntimeObject
{
public:
	// System.Int32 System.String::m_stringLength
	int32_t ___m_stringLength_0;
	// System.Char System.String::m_firstChar
	Il2CppChar ___m_firstChar_1;

public:
	inline static int32_t get_offset_of_m_stringLength_0() { return static_cast<int32_t>(offsetof(String_t, ___m_stringLength_0)); }
	inline int32_t get_m_stringLength_0() const { return ___m_stringLength_0; }
	inline int32_t* get_address_of_m_stringLength_0() { return &___m_stringLength_0; }
	inline void set_m_stringLength_0(int32_t value)
	{
		___m_stringLength_0 = value;
	}

	inline static int32_t get_offset_of_m_firstChar_1() { return static_cast<int32_t>(offsetof(String_t, ___m_firstChar_1)); }
	inline Il2CppChar get_m_firstChar_1() const { return ___m_firstChar_1; }
	inline Il2CppChar* get_address_of_m_firstChar_1() { return &___m_firstChar_1; }
	inline void set_m_firstChar_1(Il2CppChar value)
	{
		___m_firstChar_1 = value;
	}
};

struct String_t_StaticFields
{
public:
	// System.String System.String::Empty
	String_t* ___Empty_5;

public:
	inline static int32_t get_offset_of_Empty_5() { return static_cast<int32_t>(offsetof(String_t_StaticFields, ___Empty_5)); }
	inline String_t* get_Empty_5() const { return ___Empty_5; }
	inline String_t** get_address_of_Empty_5() { return &___Empty_5; }
	inline void set_Empty_5(String_t* value)
	{
		___Empty_5 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___Empty_5), (void*)value);
	}
};


// System.ValueType
struct  ValueType_t4D0C27076F7C36E76190FB3328E232BCB1CD1FFF  : public RuntimeObject
{
public:

public:
};

// Native definition for P/Invoke marshalling of System.ValueType
struct ValueType_t4D0C27076F7C36E76190FB3328E232BCB1CD1FFF_marshaled_pinvoke
{
};
// Native definition for COM marshalling of System.ValueType
struct ValueType_t4D0C27076F7C36E76190FB3328E232BCB1CD1FFF_marshaled_com
{
};

// UnityEngine.Subsystem
struct  Subsystem_t17E4AEB5537DC8AECC37EC3F6FCB46CC7D2C73F6  : public RuntimeObject
{
public:
	// UnityEngine.ISubsystemDescriptor UnityEngine.Subsystem::m_subsystemDescriptor
	RuntimeObject* ___m_subsystemDescriptor_0;

public:
	inline static int32_t get_offset_of_m_subsystemDescriptor_0() { return static_cast<int32_t>(offsetof(Subsystem_t17E4AEB5537DC8AECC37EC3F6FCB46CC7D2C73F6, ___m_subsystemDescriptor_0)); }
	inline RuntimeObject* get_m_subsystemDescriptor_0() const { return ___m_subsystemDescriptor_0; }
	inline RuntimeObject** get_address_of_m_subsystemDescriptor_0() { return &___m_subsystemDescriptor_0; }
	inline void set_m_subsystemDescriptor_0(RuntimeObject* value)
	{
		___m_subsystemDescriptor_0 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___m_subsystemDescriptor_0), (void*)value);
	}
};


// UnityEngine.XR.ARSubsystems.XRFaceSubsystem_IProvider
struct  IProvider_t7B064D81E20EE0044470073AC7EABCD30910FEFB  : public RuntimeObject
{
public:

public:
};


// System.Boolean
struct  Boolean_tB53F6830F670160873277339AA58F15CAED4399C 
{
public:
	// System.Boolean System.Boolean::m_value
	bool ___m_value_0;

public:
	inline static int32_t get_offset_of_m_value_0() { return static_cast<int32_t>(offsetof(Boolean_tB53F6830F670160873277339AA58F15CAED4399C, ___m_value_0)); }
	inline bool get_m_value_0() const { return ___m_value_0; }
	inline bool* get_address_of_m_value_0() { return &___m_value_0; }
	inline void set_m_value_0(bool value)
	{
		___m_value_0 = value;
	}
};

struct Boolean_tB53F6830F670160873277339AA58F15CAED4399C_StaticFields
{
public:
	// System.String System.Boolean::TrueString
	String_t* ___TrueString_5;
	// System.String System.Boolean::FalseString
	String_t* ___FalseString_6;

public:
	inline static int32_t get_offset_of_TrueString_5() { return static_cast<int32_t>(offsetof(Boolean_tB53F6830F670160873277339AA58F15CAED4399C_StaticFields, ___TrueString_5)); }
	inline String_t* get_TrueString_5() const { return ___TrueString_5; }
	inline String_t** get_address_of_TrueString_5() { return &___TrueString_5; }
	inline void set_TrueString_5(String_t* value)
	{
		___TrueString_5 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___TrueString_5), (void*)value);
	}

	inline static int32_t get_offset_of_FalseString_6() { return static_cast<int32_t>(offsetof(Boolean_tB53F6830F670160873277339AA58F15CAED4399C_StaticFields, ___FalseString_6)); }
	inline String_t* get_FalseString_6() const { return ___FalseString_6; }
	inline String_t** get_address_of_FalseString_6() { return &___FalseString_6; }
	inline void set_FalseString_6(String_t* value)
	{
		___FalseString_6 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___FalseString_6), (void*)value);
	}
};


// System.Enum
struct  Enum_t2AF27C02B8653AE29442467390005ABC74D8F521  : public ValueType_t4D0C27076F7C36E76190FB3328E232BCB1CD1FFF
{
public:

public:
};

struct Enum_t2AF27C02B8653AE29442467390005ABC74D8F521_StaticFields
{
public:
	// System.Char[] System.Enum::enumSeperatorCharArray
	CharU5BU5D_t4CC6ABF0AD71BEC97E3C2F1E9C5677E46D3A75C2* ___enumSeperatorCharArray_0;

public:
	inline static int32_t get_offset_of_enumSeperatorCharArray_0() { return static_cast<int32_t>(offsetof(Enum_t2AF27C02B8653AE29442467390005ABC74D8F521_StaticFields, ___enumSeperatorCharArray_0)); }
	inline CharU5BU5D_t4CC6ABF0AD71BEC97E3C2F1E9C5677E46D3A75C2* get_enumSeperatorCharArray_0() const { return ___enumSeperatorCharArray_0; }
	inline CharU5BU5D_t4CC6ABF0AD71BEC97E3C2F1E9C5677E46D3A75C2** get_address_of_enumSeperatorCharArray_0() { return &___enumSeperatorCharArray_0; }
	inline void set_enumSeperatorCharArray_0(CharU5BU5D_t4CC6ABF0AD71BEC97E3C2F1E9C5677E46D3A75C2* value)
	{
		___enumSeperatorCharArray_0 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___enumSeperatorCharArray_0), (void*)value);
	}
};

// Native definition for P/Invoke marshalling of System.Enum
struct Enum_t2AF27C02B8653AE29442467390005ABC74D8F521_marshaled_pinvoke
{
};
// Native definition for COM marshalling of System.Enum
struct Enum_t2AF27C02B8653AE29442467390005ABC74D8F521_marshaled_com
{
};

// System.IntPtr
struct  IntPtr_t 
{
public:
	// System.Void* System.IntPtr::m_value
	void* ___m_value_0;

public:
	inline static int32_t get_offset_of_m_value_0() { return static_cast<int32_t>(offsetof(IntPtr_t, ___m_value_0)); }
	inline void* get_m_value_0() const { return ___m_value_0; }
	inline void** get_address_of_m_value_0() { return &___m_value_0; }
	inline void set_m_value_0(void* value)
	{
		___m_value_0 = value;
	}
};

struct IntPtr_t_StaticFields
{
public:
	// System.IntPtr System.IntPtr::Zero
	intptr_t ___Zero_1;

public:
	inline static int32_t get_offset_of_Zero_1() { return static_cast<int32_t>(offsetof(IntPtr_t_StaticFields, ___Zero_1)); }
	inline intptr_t get_Zero_1() const { return ___Zero_1; }
	inline intptr_t* get_address_of_Zero_1() { return &___Zero_1; }
	inline void set_Zero_1(intptr_t value)
	{
		___Zero_1 = value;
	}
};


// System.Void
struct  Void_t22962CB4C05B1D89B55A6E1139F0E87A90987017 
{
public:
	union
	{
		struct
		{
		};
		uint8_t Void_t22962CB4C05B1D89B55A6E1139F0E87A90987017__padding[1];
	};

public:
};


// UnityEngine.Quaternion
struct  Quaternion_t319F3319A7D43FFA5D819AD6C0A98851F0095357 
{
public:
	// System.Single UnityEngine.Quaternion::x
	float ___x_0;
	// System.Single UnityEngine.Quaternion::y
	float ___y_1;
	// System.Single UnityEngine.Quaternion::z
	float ___z_2;
	// System.Single UnityEngine.Quaternion::w
	float ___w_3;

public:
	inline static int32_t get_offset_of_x_0() { return static_cast<int32_t>(offsetof(Quaternion_t319F3319A7D43FFA5D819AD6C0A98851F0095357, ___x_0)); }
	inline float get_x_0() const { return ___x_0; }
	inline float* get_address_of_x_0() { return &___x_0; }
	inline void set_x_0(float value)
	{
		___x_0 = value;
	}

	inline static int32_t get_offset_of_y_1() { return static_cast<int32_t>(offsetof(Quaternion_t319F3319A7D43FFA5D819AD6C0A98851F0095357, ___y_1)); }
	inline float get_y_1() const { return ___y_1; }
	inline float* get_address_of_y_1() { return &___y_1; }
	inline void set_y_1(float value)
	{
		___y_1 = value;
	}

	inline static int32_t get_offset_of_z_2() { return static_cast<int32_t>(offsetof(Quaternion_t319F3319A7D43FFA5D819AD6C0A98851F0095357, ___z_2)); }
	inline float get_z_2() const { return ___z_2; }
	inline float* get_address_of_z_2() { return &___z_2; }
	inline void set_z_2(float value)
	{
		___z_2 = value;
	}

	inline static int32_t get_offset_of_w_3() { return static_cast<int32_t>(offsetof(Quaternion_t319F3319A7D43FFA5D819AD6C0A98851F0095357, ___w_3)); }
	inline float get_w_3() const { return ___w_3; }
	inline float* get_address_of_w_3() { return &___w_3; }
	inline void set_w_3(float value)
	{
		___w_3 = value;
	}
};

struct Quaternion_t319F3319A7D43FFA5D819AD6C0A98851F0095357_StaticFields
{
public:
	// UnityEngine.Quaternion UnityEngine.Quaternion::identityQuaternion
	Quaternion_t319F3319A7D43FFA5D819AD6C0A98851F0095357  ___identityQuaternion_4;

public:
	inline static int32_t get_offset_of_identityQuaternion_4() { return static_cast<int32_t>(offsetof(Quaternion_t319F3319A7D43FFA5D819AD6C0A98851F0095357_StaticFields, ___identityQuaternion_4)); }
	inline Quaternion_t319F3319A7D43FFA5D819AD6C0A98851F0095357  get_identityQuaternion_4() const { return ___identityQuaternion_4; }
	inline Quaternion_t319F3319A7D43FFA5D819AD6C0A98851F0095357 * get_address_of_identityQuaternion_4() { return &___identityQuaternion_4; }
	inline void set_identityQuaternion_4(Quaternion_t319F3319A7D43FFA5D819AD6C0A98851F0095357  value)
	{
		___identityQuaternion_4 = value;
	}
};


// UnityEngine.Subsystem`1<UnityEngine.XR.ARSubsystems.XRFaceSubsystemDescriptor>
struct  Subsystem_1_tD8C64B16B0A4B63926221851FB0A816BF4D7374F  : public Subsystem_t17E4AEB5537DC8AECC37EC3F6FCB46CC7D2C73F6
{
public:

public:
};


// UnityEngine.Vector3
struct  Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720 
{
public:
	// System.Single UnityEngine.Vector3::x
	float ___x_2;
	// System.Single UnityEngine.Vector3::y
	float ___y_3;
	// System.Single UnityEngine.Vector3::z
	float ___z_4;

public:
	inline static int32_t get_offset_of_x_2() { return static_cast<int32_t>(offsetof(Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720, ___x_2)); }
	inline float get_x_2() const { return ___x_2; }
	inline float* get_address_of_x_2() { return &___x_2; }
	inline void set_x_2(float value)
	{
		___x_2 = value;
	}

	inline static int32_t get_offset_of_y_3() { return static_cast<int32_t>(offsetof(Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720, ___y_3)); }
	inline float get_y_3() const { return ___y_3; }
	inline float* get_address_of_y_3() { return &___y_3; }
	inline void set_y_3(float value)
	{
		___y_3 = value;
	}

	inline static int32_t get_offset_of_z_4() { return static_cast<int32_t>(offsetof(Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720, ___z_4)); }
	inline float get_z_4() const { return ___z_4; }
	inline float* get_address_of_z_4() { return &___z_4; }
	inline void set_z_4(float value)
	{
		___z_4 = value;
	}
};

struct Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720_StaticFields
{
public:
	// UnityEngine.Vector3 UnityEngine.Vector3::zeroVector
	Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720  ___zeroVector_5;
	// UnityEngine.Vector3 UnityEngine.Vector3::oneVector
	Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720  ___oneVector_6;
	// UnityEngine.Vector3 UnityEngine.Vector3::upVector
	Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720  ___upVector_7;
	// UnityEngine.Vector3 UnityEngine.Vector3::downVector
	Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720  ___downVector_8;
	// UnityEngine.Vector3 UnityEngine.Vector3::leftVector
	Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720  ___leftVector_9;
	// UnityEngine.Vector3 UnityEngine.Vector3::rightVector
	Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720  ___rightVector_10;
	// UnityEngine.Vector3 UnityEngine.Vector3::forwardVector
	Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720  ___forwardVector_11;
	// UnityEngine.Vector3 UnityEngine.Vector3::backVector
	Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720  ___backVector_12;
	// UnityEngine.Vector3 UnityEngine.Vector3::positiveInfinityVector
	Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720  ___positiveInfinityVector_13;
	// UnityEngine.Vector3 UnityEngine.Vector3::negativeInfinityVector
	Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720  ___negativeInfinityVector_14;

public:
	inline static int32_t get_offset_of_zeroVector_5() { return static_cast<int32_t>(offsetof(Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720_StaticFields, ___zeroVector_5)); }
	inline Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720  get_zeroVector_5() const { return ___zeroVector_5; }
	inline Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720 * get_address_of_zeroVector_5() { return &___zeroVector_5; }
	inline void set_zeroVector_5(Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720  value)
	{
		___zeroVector_5 = value;
	}

	inline static int32_t get_offset_of_oneVector_6() { return static_cast<int32_t>(offsetof(Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720_StaticFields, ___oneVector_6)); }
	inline Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720  get_oneVector_6() const { return ___oneVector_6; }
	inline Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720 * get_address_of_oneVector_6() { return &___oneVector_6; }
	inline void set_oneVector_6(Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720  value)
	{
		___oneVector_6 = value;
	}

	inline static int32_t get_offset_of_upVector_7() { return static_cast<int32_t>(offsetof(Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720_StaticFields, ___upVector_7)); }
	inline Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720  get_upVector_7() const { return ___upVector_7; }
	inline Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720 * get_address_of_upVector_7() { return &___upVector_7; }
	inline void set_upVector_7(Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720  value)
	{
		___upVector_7 = value;
	}

	inline static int32_t get_offset_of_downVector_8() { return static_cast<int32_t>(offsetof(Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720_StaticFields, ___downVector_8)); }
	inline Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720  get_downVector_8() const { return ___downVector_8; }
	inline Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720 * get_address_of_downVector_8() { return &___downVector_8; }
	inline void set_downVector_8(Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720  value)
	{
		___downVector_8 = value;
	}

	inline static int32_t get_offset_of_leftVector_9() { return static_cast<int32_t>(offsetof(Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720_StaticFields, ___leftVector_9)); }
	inline Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720  get_leftVector_9() const { return ___leftVector_9; }
	inline Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720 * get_address_of_leftVector_9() { return &___leftVector_9; }
	inline void set_leftVector_9(Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720  value)
	{
		___leftVector_9 = value;
	}

	inline static int32_t get_offset_of_rightVector_10() { return static_cast<int32_t>(offsetof(Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720_StaticFields, ___rightVector_10)); }
	inline Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720  get_rightVector_10() const { return ___rightVector_10; }
	inline Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720 * get_address_of_rightVector_10() { return &___rightVector_10; }
	inline void set_rightVector_10(Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720  value)
	{
		___rightVector_10 = value;
	}

	inline static int32_t get_offset_of_forwardVector_11() { return static_cast<int32_t>(offsetof(Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720_StaticFields, ___forwardVector_11)); }
	inline Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720  get_forwardVector_11() const { return ___forwardVector_11; }
	inline Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720 * get_address_of_forwardVector_11() { return &___forwardVector_11; }
	inline void set_forwardVector_11(Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720  value)
	{
		___forwardVector_11 = value;
	}

	inline static int32_t get_offset_of_backVector_12() { return static_cast<int32_t>(offsetof(Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720_StaticFields, ___backVector_12)); }
	inline Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720  get_backVector_12() const { return ___backVector_12; }
	inline Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720 * get_address_of_backVector_12() { return &___backVector_12; }
	inline void set_backVector_12(Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720  value)
	{
		___backVector_12 = value;
	}

	inline static int32_t get_offset_of_positiveInfinityVector_13() { return static_cast<int32_t>(offsetof(Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720_StaticFields, ___positiveInfinityVector_13)); }
	inline Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720  get_positiveInfinityVector_13() const { return ___positiveInfinityVector_13; }
	inline Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720 * get_address_of_positiveInfinityVector_13() { return &___positiveInfinityVector_13; }
	inline void set_positiveInfinityVector_13(Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720  value)
	{
		___positiveInfinityVector_13 = value;
	}

	inline static int32_t get_offset_of_negativeInfinityVector_14() { return static_cast<int32_t>(offsetof(Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720_StaticFields, ___negativeInfinityVector_14)); }
	inline Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720  get_negativeInfinityVector_14() const { return ___negativeInfinityVector_14; }
	inline Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720 * get_address_of_negativeInfinityVector_14() { return &___negativeInfinityVector_14; }
	inline void set_negativeInfinityVector_14(Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720  value)
	{
		___negativeInfinityVector_14 = value;
	}
};


// UnityEngine.XR.ARKit.ARKitFaceSubsystem_Provider
struct  Provider_t1A0EF7D1C90CB7506DABB17AA054D7FE2B5493F2  : public IProvider_t7B064D81E20EE0044470073AC7EABCD30910FEFB
{
public:

public:
};


// UnityEngine.XR.ARSubsystems.TrackableId
struct  TrackableId_tA7E19AFE62176E25E3759548887E9068E1E4AE47 
{
public:
	// System.UInt64 UnityEngine.XR.ARSubsystems.TrackableId::m_SubId1
	uint64_t ___m_SubId1_1;
	// System.UInt64 UnityEngine.XR.ARSubsystems.TrackableId::m_SubId2
	uint64_t ___m_SubId2_2;

public:
	inline static int32_t get_offset_of_m_SubId1_1() { return static_cast<int32_t>(offsetof(TrackableId_tA7E19AFE62176E25E3759548887E9068E1E4AE47, ___m_SubId1_1)); }
	inline uint64_t get_m_SubId1_1() const { return ___m_SubId1_1; }
	inline uint64_t* get_address_of_m_SubId1_1() { return &___m_SubId1_1; }
	inline void set_m_SubId1_1(uint64_t value)
	{
		___m_SubId1_1 = value;
	}

	inline static int32_t get_offset_of_m_SubId2_2() { return static_cast<int32_t>(offsetof(TrackableId_tA7E19AFE62176E25E3759548887E9068E1E4AE47, ___m_SubId2_2)); }
	inline uint64_t get_m_SubId2_2() const { return ___m_SubId2_2; }
	inline uint64_t* get_address_of_m_SubId2_2() { return &___m_SubId2_2; }
	inline void set_m_SubId2_2(uint64_t value)
	{
		___m_SubId2_2 = value;
	}
};

struct TrackableId_tA7E19AFE62176E25E3759548887E9068E1E4AE47_StaticFields
{
public:
	// UnityEngine.XR.ARSubsystems.TrackableId UnityEngine.XR.ARSubsystems.TrackableId::s_InvalidId
	TrackableId_tA7E19AFE62176E25E3759548887E9068E1E4AE47  ___s_InvalidId_0;

public:
	inline static int32_t get_offset_of_s_InvalidId_0() { return static_cast<int32_t>(offsetof(TrackableId_tA7E19AFE62176E25E3759548887E9068E1E4AE47_StaticFields, ___s_InvalidId_0)); }
	inline TrackableId_tA7E19AFE62176E25E3759548887E9068E1E4AE47  get_s_InvalidId_0() const { return ___s_InvalidId_0; }
	inline TrackableId_tA7E19AFE62176E25E3759548887E9068E1E4AE47 * get_address_of_s_InvalidId_0() { return &___s_InvalidId_0; }
	inline void set_s_InvalidId_0(TrackableId_tA7E19AFE62176E25E3759548887E9068E1E4AE47  value)
	{
		___s_InvalidId_0 = value;
	}
};


// System.Reflection.BindingFlags
struct  BindingFlags_tE35C91D046E63A1B92BB9AB909FCF9DA84379ED0 
{
public:
	// System.Int32 System.Reflection.BindingFlags::value__
	int32_t ___value___2;

public:
	inline static int32_t get_offset_of_value___2() { return static_cast<int32_t>(offsetof(BindingFlags_tE35C91D046E63A1B92BB9AB909FCF9DA84379ED0, ___value___2)); }
	inline int32_t get_value___2() const { return ___value___2; }
	inline int32_t* get_address_of_value___2() { return &___value___2; }
	inline void set_value___2(int32_t value)
	{
		___value___2 = value;
	}
};


// System.RuntimeTypeHandle
struct  RuntimeTypeHandle_t7B542280A22F0EC4EAC2061C29178845847A8B2D 
{
public:
	// System.IntPtr System.RuntimeTypeHandle::value
	intptr_t ___value_0;

public:
	inline static int32_t get_offset_of_value_0() { return static_cast<int32_t>(offsetof(RuntimeTypeHandle_t7B542280A22F0EC4EAC2061C29178845847A8B2D, ___value_0)); }
	inline intptr_t get_value_0() const { return ___value_0; }
	inline intptr_t* get_address_of_value_0() { return &___value_0; }
	inline void set_value_0(intptr_t value)
	{
		___value_0 = value;
	}
};


// Unity.Collections.Allocator
struct  Allocator_t62A091275262E7067EAAD565B67764FA877D58D6 
{
public:
	// System.Int32 Unity.Collections.Allocator::value__
	int32_t ___value___2;

public:
	inline static int32_t get_offset_of_value___2() { return static_cast<int32_t>(offsetof(Allocator_t62A091275262E7067EAAD565B67764FA877D58D6, ___value___2)); }
	inline int32_t get_value___2() const { return ___value___2; }
	inline int32_t* get_address_of_value___2() { return &___value___2; }
	inline void set_value___2(int32_t value)
	{
		___value___2 = value;
	}
};


// UnityEngine.Pose
struct  Pose_t2997DE3CB3863E4D78FCF42B46FC481818823F29 
{
public:
	// UnityEngine.Vector3 UnityEngine.Pose::position
	Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720  ___position_0;
	// UnityEngine.Quaternion UnityEngine.Pose::rotation
	Quaternion_t319F3319A7D43FFA5D819AD6C0A98851F0095357  ___rotation_1;

public:
	inline static int32_t get_offset_of_position_0() { return static_cast<int32_t>(offsetof(Pose_t2997DE3CB3863E4D78FCF42B46FC481818823F29, ___position_0)); }
	inline Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720  get_position_0() const { return ___position_0; }
	inline Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720 * get_address_of_position_0() { return &___position_0; }
	inline void set_position_0(Vector3_tDCF05E21F632FE2BA260C06E0D10CA81513E6720  value)
	{
		___position_0 = value;
	}

	inline static int32_t get_offset_of_rotation_1() { return static_cast<int32_t>(offsetof(Pose_t2997DE3CB3863E4D78FCF42B46FC481818823F29, ___rotation_1)); }
	inline Quaternion_t319F3319A7D43FFA5D819AD6C0A98851F0095357  get_rotation_1() const { return ___rotation_1; }
	inline Quaternion_t319F3319A7D43FFA5D819AD6C0A98851F0095357 * get_address_of_rotation_1() { return &___rotation_1; }
	inline void set_rotation_1(Quaternion_t319F3319A7D43FFA5D819AD6C0A98851F0095357  value)
	{
		___rotation_1 = value;
	}
};

struct Pose_t2997DE3CB3863E4D78FCF42B46FC481818823F29_StaticFields
{
public:
	// UnityEngine.Pose UnityEngine.Pose::k_Identity
	Pose_t2997DE3CB3863E4D78FCF42B46FC481818823F29  ___k_Identity_2;

public:
	inline static int32_t get_offset_of_k_Identity_2() { return static_cast<int32_t>(offsetof(Pose_t2997DE3CB3863E4D78FCF42B46FC481818823F29_StaticFields, ___k_Identity_2)); }
	inline Pose_t2997DE3CB3863E4D78FCF42B46FC481818823F29  get_k_Identity_2() const { return ___k_Identity_2; }
	inline Pose_t2997DE3CB3863E4D78FCF42B46FC481818823F29 * get_address_of_k_Identity_2() { return &___k_Identity_2; }
	inline void set_k_Identity_2(Pose_t2997DE3CB3863E4D78FCF42B46FC481818823F29  value)
	{
		___k_Identity_2 = value;
	}
};


// UnityEngine.XR.ARSubsystems.FaceSubsystemCapabilities
struct  FaceSubsystemCapabilities_t771E6D24E1BD202CC35FF0ECCF73C92875D0B70A 
{
public:
	// System.Int32 UnityEngine.XR.ARSubsystems.FaceSubsystemCapabilities::value__
	int32_t ___value___2;

public:
	inline static int32_t get_offset_of_value___2() { return static_cast<int32_t>(offsetof(FaceSubsystemCapabilities_t771E6D24E1BD202CC35FF0ECCF73C92875D0B70A, ___value___2)); }
	inline int32_t get_value___2() const { return ___value___2; }
	inline int32_t* get_address_of_value___2() { return &___value___2; }
	inline void set_value___2(int32_t value)
	{
		___value___2 = value;
	}
};


// UnityEngine.XR.ARSubsystems.TrackingState
struct  TrackingState_t124D9E603E4E0453A85409CF7762EE8C946233F6 
{
public:
	// System.Int32 UnityEngine.XR.ARSubsystems.TrackingState::value__
	int32_t ___value___2;

public:
	inline static int32_t get_offset_of_value___2() { return static_cast<int32_t>(offsetof(TrackingState_t124D9E603E4E0453A85409CF7762EE8C946233F6, ___value___2)); }
	inline int32_t get_value___2() const { return ___value___2; }
	inline int32_t* get_address_of_value___2() { return &___value___2; }
	inline void set_value___2(int32_t value)
	{
		___value___2 = value;
	}
};


// UnityEngine.XR.ARSubsystems.TrackingSubsystem`2<UnityEngine.XR.ARSubsystems.XRFace,UnityEngine.XR.ARSubsystems.XRFaceSubsystemDescriptor>
struct  TrackingSubsystem_2_t0FED3C9C04703698E2508803246650F43C7430AB  : public Subsystem_1_tD8C64B16B0A4B63926221851FB0A816BF4D7374F
{
public:
	// System.Boolean UnityEngine.XR.ARSubsystems.TrackingSubsystem`2::m_Running
	bool ___m_Running_1;

public:
	inline static int32_t get_offset_of_m_Running_1() { return static_cast<int32_t>(offsetof(TrackingSubsystem_2_t0FED3C9C04703698E2508803246650F43C7430AB, ___m_Running_1)); }
	inline bool get_m_Running_1() const { return ___m_Running_1; }
	inline bool* get_address_of_m_Running_1() { return &___m_Running_1; }
	inline void set_m_Running_1(bool value)
	{
		___m_Running_1 = value;
	}
};


// System.Type
struct  Type_t  : public MemberInfo_t
{
public:
	// System.RuntimeTypeHandle System.Type::_impl
	RuntimeTypeHandle_t7B542280A22F0EC4EAC2061C29178845847A8B2D  ____impl_9;

public:
	inline static int32_t get_offset_of__impl_9() { return static_cast<int32_t>(offsetof(Type_t, ____impl_9)); }
	inline RuntimeTypeHandle_t7B542280A22F0EC4EAC2061C29178845847A8B2D  get__impl_9() const { return ____impl_9; }
	inline RuntimeTypeHandle_t7B542280A22F0EC4EAC2061C29178845847A8B2D * get_address_of__impl_9() { return &____impl_9; }
	inline void set__impl_9(RuntimeTypeHandle_t7B542280A22F0EC4EAC2061C29178845847A8B2D  value)
	{
		____impl_9 = value;
	}
};

struct Type_t_StaticFields
{
public:
	// System.Reflection.MemberFilter System.Type::FilterAttribute
	MemberFilter_t25C1BD92C42BE94426E300787C13C452CB89B381 * ___FilterAttribute_0;
	// System.Reflection.MemberFilter System.Type::FilterName
	MemberFilter_t25C1BD92C42BE94426E300787C13C452CB89B381 * ___FilterName_1;
	// System.Reflection.MemberFilter System.Type::FilterNameIgnoreCase
	MemberFilter_t25C1BD92C42BE94426E300787C13C452CB89B381 * ___FilterNameIgnoreCase_2;
	// System.Object System.Type::Missing
	RuntimeObject * ___Missing_3;
	// System.Char System.Type::Delimiter
	Il2CppChar ___Delimiter_4;
	// System.Type[] System.Type::EmptyTypes
	TypeU5BU5D_t7FE623A666B49176DE123306221193E888A12F5F* ___EmptyTypes_5;
	// System.Reflection.Binder System.Type::defaultBinder
	Binder_t4D5CB06963501D32847C057B57157D6DC49CA759 * ___defaultBinder_6;

public:
	inline static int32_t get_offset_of_FilterAttribute_0() { return static_cast<int32_t>(offsetof(Type_t_StaticFields, ___FilterAttribute_0)); }
	inline MemberFilter_t25C1BD92C42BE94426E300787C13C452CB89B381 * get_FilterAttribute_0() const { return ___FilterAttribute_0; }
	inline MemberFilter_t25C1BD92C42BE94426E300787C13C452CB89B381 ** get_address_of_FilterAttribute_0() { return &___FilterAttribute_0; }
	inline void set_FilterAttribute_0(MemberFilter_t25C1BD92C42BE94426E300787C13C452CB89B381 * value)
	{
		___FilterAttribute_0 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___FilterAttribute_0), (void*)value);
	}

	inline static int32_t get_offset_of_FilterName_1() { return static_cast<int32_t>(offsetof(Type_t_StaticFields, ___FilterName_1)); }
	inline MemberFilter_t25C1BD92C42BE94426E300787C13C452CB89B381 * get_FilterName_1() const { return ___FilterName_1; }
	inline MemberFilter_t25C1BD92C42BE94426E300787C13C452CB89B381 ** get_address_of_FilterName_1() { return &___FilterName_1; }
	inline void set_FilterName_1(MemberFilter_t25C1BD92C42BE94426E300787C13C452CB89B381 * value)
	{
		___FilterName_1 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___FilterName_1), (void*)value);
	}

	inline static int32_t get_offset_of_FilterNameIgnoreCase_2() { return static_cast<int32_t>(offsetof(Type_t_StaticFields, ___FilterNameIgnoreCase_2)); }
	inline MemberFilter_t25C1BD92C42BE94426E300787C13C452CB89B381 * get_FilterNameIgnoreCase_2() const { return ___FilterNameIgnoreCase_2; }
	inline MemberFilter_t25C1BD92C42BE94426E300787C13C452CB89B381 ** get_address_of_FilterNameIgnoreCase_2() { return &___FilterNameIgnoreCase_2; }
	inline void set_FilterNameIgnoreCase_2(MemberFilter_t25C1BD92C42BE94426E300787C13C452CB89B381 * value)
	{
		___FilterNameIgnoreCase_2 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___FilterNameIgnoreCase_2), (void*)value);
	}

	inline static int32_t get_offset_of_Missing_3() { return static_cast<int32_t>(offsetof(Type_t_StaticFields, ___Missing_3)); }
	inline RuntimeObject * get_Missing_3() const { return ___Missing_3; }
	inline RuntimeObject ** get_address_of_Missing_3() { return &___Missing_3; }
	inline void set_Missing_3(RuntimeObject * value)
	{
		___Missing_3 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___Missing_3), (void*)value);
	}

	inline static int32_t get_offset_of_Delimiter_4() { return static_cast<int32_t>(offsetof(Type_t_StaticFields, ___Delimiter_4)); }
	inline Il2CppChar get_Delimiter_4() const { return ___Delimiter_4; }
	inline Il2CppChar* get_address_of_Delimiter_4() { return &___Delimiter_4; }
	inline void set_Delimiter_4(Il2CppChar value)
	{
		___Delimiter_4 = value;
	}

	inline static int32_t get_offset_of_EmptyTypes_5() { return static_cast<int32_t>(offsetof(Type_t_StaticFields, ___EmptyTypes_5)); }
	inline TypeU5BU5D_t7FE623A666B49176DE123306221193E888A12F5F* get_EmptyTypes_5() const { return ___EmptyTypes_5; }
	inline TypeU5BU5D_t7FE623A666B49176DE123306221193E888A12F5F** get_address_of_EmptyTypes_5() { return &___EmptyTypes_5; }
	inline void set_EmptyTypes_5(TypeU5BU5D_t7FE623A666B49176DE123306221193E888A12F5F* value)
	{
		___EmptyTypes_5 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___EmptyTypes_5), (void*)value);
	}

	inline static int32_t get_offset_of_defaultBinder_6() { return static_cast<int32_t>(offsetof(Type_t_StaticFields, ___defaultBinder_6)); }
	inline Binder_t4D5CB06963501D32847C057B57157D6DC49CA759 * get_defaultBinder_6() const { return ___defaultBinder_6; }
	inline Binder_t4D5CB06963501D32847C057B57157D6DC49CA759 ** get_address_of_defaultBinder_6() { return &___defaultBinder_6; }
	inline void set_defaultBinder_6(Binder_t4D5CB06963501D32847C057B57157D6DC49CA759 * value)
	{
		___defaultBinder_6 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___defaultBinder_6), (void*)value);
	}
};


// Unity.Collections.NativeArray`1<UnityEngine.Vector2>
struct  NativeArray_1_t86AEDFC03CDAC131E54ED6A68B102EBD947A3F71 
{
public:
	// System.Void* Unity.Collections.NativeArray`1::m_Buffer
	void* ___m_Buffer_0;
	// System.Int32 Unity.Collections.NativeArray`1::m_Length
	int32_t ___m_Length_1;
	// Unity.Collections.Allocator Unity.Collections.NativeArray`1::m_AllocatorLabel
	int32_t ___m_AllocatorLabel_2;

public:
	inline static int32_t get_offset_of_m_Buffer_0() { return static_cast<int32_t>(offsetof(NativeArray_1_t86AEDFC03CDAC131E54ED6A68B102EBD947A3F71, ___m_Buffer_0)); }
	inline void* get_m_Buffer_0() const { return ___m_Buffer_0; }
	inline void** get_address_of_m_Buffer_0() { return &___m_Buffer_0; }
	inline void set_m_Buffer_0(void* value)
	{
		___m_Buffer_0 = value;
	}

	inline static int32_t get_offset_of_m_Length_1() { return static_cast<int32_t>(offsetof(NativeArray_1_t86AEDFC03CDAC131E54ED6A68B102EBD947A3F71, ___m_Length_1)); }
	inline int32_t get_m_Length_1() const { return ___m_Length_1; }
	inline int32_t* get_address_of_m_Length_1() { return &___m_Length_1; }
	inline void set_m_Length_1(int32_t value)
	{
		___m_Length_1 = value;
	}

	inline static int32_t get_offset_of_m_AllocatorLabel_2() { return static_cast<int32_t>(offsetof(NativeArray_1_t86AEDFC03CDAC131E54ED6A68B102EBD947A3F71, ___m_AllocatorLabel_2)); }
	inline int32_t get_m_AllocatorLabel_2() const { return ___m_AllocatorLabel_2; }
	inline int32_t* get_address_of_m_AllocatorLabel_2() { return &___m_AllocatorLabel_2; }
	inline void set_m_AllocatorLabel_2(int32_t value)
	{
		___m_AllocatorLabel_2 = value;
	}
};


// Unity.Collections.NativeArray`1<UnityEngine.Vector3>
struct  NativeArray_1_t20B0E97D613353CCC2889E9B3D97A5612374FE74 
{
public:
	// System.Void* Unity.Collections.NativeArray`1::m_Buffer
	void* ___m_Buffer_0;
	// System.Int32 Unity.Collections.NativeArray`1::m_Length
	int32_t ___m_Length_1;
	// Unity.Collections.Allocator Unity.Collections.NativeArray`1::m_AllocatorLabel
	int32_t ___m_AllocatorLabel_2;

public:
	inline static int32_t get_offset_of_m_Buffer_0() { return static_cast<int32_t>(offsetof(NativeArray_1_t20B0E97D613353CCC2889E9B3D97A5612374FE74, ___m_Buffer_0)); }
	inline void* get_m_Buffer_0() const { return ___m_Buffer_0; }
	inline void** get_address_of_m_Buffer_0() { return &___m_Buffer_0; }
	inline void set_m_Buffer_0(void* value)
	{
		___m_Buffer_0 = value;
	}

	inline static int32_t get_offset_of_m_Length_1() { return static_cast<int32_t>(offsetof(NativeArray_1_t20B0E97D613353CCC2889E9B3D97A5612374FE74, ___m_Length_1)); }
	inline int32_t get_m_Length_1() const { return ___m_Length_1; }
	inline int32_t* get_address_of_m_Length_1() { return &___m_Length_1; }
	inline void set_m_Length_1(int32_t value)
	{
		___m_Length_1 = value;
	}

	inline static int32_t get_offset_of_m_AllocatorLabel_2() { return static_cast<int32_t>(offsetof(NativeArray_1_t20B0E97D613353CCC2889E9B3D97A5612374FE74, ___m_AllocatorLabel_2)); }
	inline int32_t get_m_AllocatorLabel_2() const { return ___m_AllocatorLabel_2; }
	inline int32_t* get_address_of_m_AllocatorLabel_2() { return &___m_AllocatorLabel_2; }
	inline void set_m_AllocatorLabel_2(int32_t value)
	{
		___m_AllocatorLabel_2 = value;
	}
};


// Unity.Collections.NativeArray`1<UnityEngine.Vector4>
struct  NativeArray_1_t32E6297AF854BD125529357115F7C02BA25C4C96 
{
public:
	// System.Void* Unity.Collections.NativeArray`1::m_Buffer
	void* ___m_Buffer_0;
	// System.Int32 Unity.Collections.NativeArray`1::m_Length
	int32_t ___m_Length_1;
	// Unity.Collections.Allocator Unity.Collections.NativeArray`1::m_AllocatorLabel
	int32_t ___m_AllocatorLabel_2;

public:
	inline static int32_t get_offset_of_m_Buffer_0() { return static_cast<int32_t>(offsetof(NativeArray_1_t32E6297AF854BD125529357115F7C02BA25C4C96, ___m_Buffer_0)); }
	inline void* get_m_Buffer_0() const { return ___m_Buffer_0; }
	inline void** get_address_of_m_Buffer_0() { return &___m_Buffer_0; }
	inline void set_m_Buffer_0(void* value)
	{
		___m_Buffer_0 = value;
	}

	inline static int32_t get_offset_of_m_Length_1() { return static_cast<int32_t>(offsetof(NativeArray_1_t32E6297AF854BD125529357115F7C02BA25C4C96, ___m_Length_1)); }
	inline int32_t get_m_Length_1() const { return ___m_Length_1; }
	inline int32_t* get_address_of_m_Length_1() { return &___m_Length_1; }
	inline void set_m_Length_1(int32_t value)
	{
		___m_Length_1 = value;
	}

	inline static int32_t get_offset_of_m_AllocatorLabel_2() { return static_cast<int32_t>(offsetof(NativeArray_1_t32E6297AF854BD125529357115F7C02BA25C4C96, ___m_AllocatorLabel_2)); }
	inline int32_t get_m_AllocatorLabel_2() const { return ___m_AllocatorLabel_2; }
	inline int32_t* get_address_of_m_AllocatorLabel_2() { return &___m_AllocatorLabel_2; }
	inline void set_m_AllocatorLabel_2(int32_t value)
	{
		___m_AllocatorLabel_2 = value;
	}
};


// Unity.Collections.NativeArray`1<UnityEngine.XR.ARKit.ARKitFaceSubsystem_Provider_Triangle`1<System.Int16>>
struct  NativeArray_1_t649186934C1B59485B8E0757D760C6DF766F1CBD 
{
public:
	// System.Void* Unity.Collections.NativeArray`1::m_Buffer
	void* ___m_Buffer_0;
	// System.Int32 Unity.Collections.NativeArray`1::m_Length
	int32_t ___m_Length_1;
	// Unity.Collections.Allocator Unity.Collections.NativeArray`1::m_AllocatorLabel
	int32_t ___m_AllocatorLabel_2;

public:
	inline static int32_t get_offset_of_m_Buffer_0() { return static_cast<int32_t>(offsetof(NativeArray_1_t649186934C1B59485B8E0757D760C6DF766F1CBD, ___m_Buffer_0)); }
	inline void* get_m_Buffer_0() const { return ___m_Buffer_0; }
	inline void** get_address_of_m_Buffer_0() { return &___m_Buffer_0; }
	inline void set_m_Buffer_0(void* value)
	{
		___m_Buffer_0 = value;
	}

	inline static int32_t get_offset_of_m_Length_1() { return static_cast<int32_t>(offsetof(NativeArray_1_t649186934C1B59485B8E0757D760C6DF766F1CBD, ___m_Length_1)); }
	inline int32_t get_m_Length_1() const { return ___m_Length_1; }
	inline int32_t* get_address_of_m_Length_1() { return &___m_Length_1; }
	inline void set_m_Length_1(int32_t value)
	{
		___m_Length_1 = value;
	}

	inline static int32_t get_offset_of_m_AllocatorLabel_2() { return static_cast<int32_t>(offsetof(NativeArray_1_t649186934C1B59485B8E0757D760C6DF766F1CBD, ___m_AllocatorLabel_2)); }
	inline int32_t get_m_AllocatorLabel_2() const { return ___m_AllocatorLabel_2; }
	inline int32_t* get_address_of_m_AllocatorLabel_2() { return &___m_AllocatorLabel_2; }
	inline void set_m_AllocatorLabel_2(int32_t value)
	{
		___m_AllocatorLabel_2 = value;
	}
};


// Unity.Collections.NativeArray`1<UnityEngine.XR.ARKit.ARKitFaceSubsystem_Provider_Triangle`1<System.Int32>>
struct  NativeArray_1_t36042C6730263F193FA4F505DB694BAC9C7344D2 
{
public:
	// System.Void* Unity.Collections.NativeArray`1::m_Buffer
	void* ___m_Buffer_0;
	// System.Int32 Unity.Collections.NativeArray`1::m_Length
	int32_t ___m_Length_1;
	// Unity.Collections.Allocator Unity.Collections.NativeArray`1::m_AllocatorLabel
	int32_t ___m_AllocatorLabel_2;

public:
	inline static int32_t get_offset_of_m_Buffer_0() { return static_cast<int32_t>(offsetof(NativeArray_1_t36042C6730263F193FA4F505DB694BAC9C7344D2, ___m_Buffer_0)); }
	inline void* get_m_Buffer_0() const { return ___m_Buffer_0; }
	inline void** get_address_of_m_Buffer_0() { return &___m_Buffer_0; }
	inline void set_m_Buffer_0(void* value)
	{
		___m_Buffer_0 = value;
	}

	inline static int32_t get_offset_of_m_Length_1() { return static_cast<int32_t>(offsetof(NativeArray_1_t36042C6730263F193FA4F505DB694BAC9C7344D2, ___m_Length_1)); }
	inline int32_t get_m_Length_1() const { return ___m_Length_1; }
	inline int32_t* get_address_of_m_Length_1() { return &___m_Length_1; }
	inline void set_m_Length_1(int32_t value)
	{
		___m_Length_1 = value;
	}

	inline static int32_t get_offset_of_m_AllocatorLabel_2() { return static_cast<int32_t>(offsetof(NativeArray_1_t36042C6730263F193FA4F505DB694BAC9C7344D2, ___m_AllocatorLabel_2)); }
	inline int32_t get_m_AllocatorLabel_2() const { return ___m_AllocatorLabel_2; }
	inline int32_t* get_address_of_m_AllocatorLabel_2() { return &___m_AllocatorLabel_2; }
	inline void set_m_AllocatorLabel_2(int32_t value)
	{
		___m_AllocatorLabel_2 = value;
	}
};


// UnityEngine.XR.ARSubsystems.FaceSubsystemParams
struct  FaceSubsystemParams_t088DAC0A926CF6ED204F58C235C817966D718542 
{
public:
	// System.String UnityEngine.XR.ARSubsystems.FaceSubsystemParams::<id>k__BackingField
	String_t* ___U3CidU3Ek__BackingField_0;
	// System.Type UnityEngine.XR.ARSubsystems.FaceSubsystemParams::<subsystemImplementationType>k__BackingField
	Type_t * ___U3CsubsystemImplementationTypeU3Ek__BackingField_1;
	// UnityEngine.XR.ARSubsystems.FaceSubsystemCapabilities UnityEngine.XR.ARSubsystems.FaceSubsystemParams::m_Capabilities
	int32_t ___m_Capabilities_2;

public:
	inline static int32_t get_offset_of_U3CidU3Ek__BackingField_0() { return static_cast<int32_t>(offsetof(FaceSubsystemParams_t088DAC0A926CF6ED204F58C235C817966D718542, ___U3CidU3Ek__BackingField_0)); }
	inline String_t* get_U3CidU3Ek__BackingField_0() const { return ___U3CidU3Ek__BackingField_0; }
	inline String_t** get_address_of_U3CidU3Ek__BackingField_0() { return &___U3CidU3Ek__BackingField_0; }
	inline void set_U3CidU3Ek__BackingField_0(String_t* value)
	{
		___U3CidU3Ek__BackingField_0 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___U3CidU3Ek__BackingField_0), (void*)value);
	}

	inline static int32_t get_offset_of_U3CsubsystemImplementationTypeU3Ek__BackingField_1() { return static_cast<int32_t>(offsetof(FaceSubsystemParams_t088DAC0A926CF6ED204F58C235C817966D718542, ___U3CsubsystemImplementationTypeU3Ek__BackingField_1)); }
	inline Type_t * get_U3CsubsystemImplementationTypeU3Ek__BackingField_1() const { return ___U3CsubsystemImplementationTypeU3Ek__BackingField_1; }
	inline Type_t ** get_address_of_U3CsubsystemImplementationTypeU3Ek__BackingField_1() { return &___U3CsubsystemImplementationTypeU3Ek__BackingField_1; }
	inline void set_U3CsubsystemImplementationTypeU3Ek__BackingField_1(Type_t * value)
	{
		___U3CsubsystemImplementationTypeU3Ek__BackingField_1 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___U3CsubsystemImplementationTypeU3Ek__BackingField_1), (void*)value);
	}

	inline static int32_t get_offset_of_m_Capabilities_2() { return static_cast<int32_t>(offsetof(FaceSubsystemParams_t088DAC0A926CF6ED204F58C235C817966D718542, ___m_Capabilities_2)); }
	inline int32_t get_m_Capabilities_2() const { return ___m_Capabilities_2; }
	inline int32_t* get_address_of_m_Capabilities_2() { return &___m_Capabilities_2; }
	inline void set_m_Capabilities_2(int32_t value)
	{
		___m_Capabilities_2 = value;
	}
};

// Native definition for P/Invoke marshalling of UnityEngine.XR.ARSubsystems.FaceSubsystemParams
struct FaceSubsystemParams_t088DAC0A926CF6ED204F58C235C817966D718542_marshaled_pinvoke
{
	char* ___U3CidU3Ek__BackingField_0;
	Type_t * ___U3CsubsystemImplementationTypeU3Ek__BackingField_1;
	int32_t ___m_Capabilities_2;
};
// Native definition for COM marshalling of UnityEngine.XR.ARSubsystems.FaceSubsystemParams
struct FaceSubsystemParams_t088DAC0A926CF6ED204F58C235C817966D718542_marshaled_com
{
	Il2CppChar* ___U3CidU3Ek__BackingField_0;
	Type_t * ___U3CsubsystemImplementationTypeU3Ek__BackingField_1;
	int32_t ___m_Capabilities_2;
};

// UnityEngine.XR.ARSubsystems.XRFace
struct  XRFace_tF2B2E9B06813BA74F5DAFD527FD249DD1002B7C7 
{
public:
	// UnityEngine.XR.ARSubsystems.TrackableId UnityEngine.XR.ARSubsystems.XRFace::m_TrackableId
	TrackableId_tA7E19AFE62176E25E3759548887E9068E1E4AE47  ___m_TrackableId_0;
	// UnityEngine.Pose UnityEngine.XR.ARSubsystems.XRFace::m_Pose
	Pose_t2997DE3CB3863E4D78FCF42B46FC481818823F29  ___m_Pose_1;
	// UnityEngine.XR.ARSubsystems.TrackingState UnityEngine.XR.ARSubsystems.XRFace::m_TrackingState
	int32_t ___m_TrackingState_2;
	// System.IntPtr UnityEngine.XR.ARSubsystems.XRFace::m_NativePtr
	intptr_t ___m_NativePtr_3;

public:
	inline static int32_t get_offset_of_m_TrackableId_0() { return static_cast<int32_t>(offsetof(XRFace_tF2B2E9B06813BA74F5DAFD527FD249DD1002B7C7, ___m_TrackableId_0)); }
	inline TrackableId_tA7E19AFE62176E25E3759548887E9068E1E4AE47  get_m_TrackableId_0() const { return ___m_TrackableId_0; }
	inline TrackableId_tA7E19AFE62176E25E3759548887E9068E1E4AE47 * get_address_of_m_TrackableId_0() { return &___m_TrackableId_0; }
	inline void set_m_TrackableId_0(TrackableId_tA7E19AFE62176E25E3759548887E9068E1E4AE47  value)
	{
		___m_TrackableId_0 = value;
	}

	inline static int32_t get_offset_of_m_Pose_1() { return static_cast<int32_t>(offsetof(XRFace_tF2B2E9B06813BA74F5DAFD527FD249DD1002B7C7, ___m_Pose_1)); }
	inline Pose_t2997DE3CB3863E4D78FCF42B46FC481818823F29  get_m_Pose_1() const { return ___m_Pose_1; }
	inline Pose_t2997DE3CB3863E4D78FCF42B46FC481818823F29 * get_address_of_m_Pose_1() { return &___m_Pose_1; }
	inline void set_m_Pose_1(Pose_t2997DE3CB3863E4D78FCF42B46FC481818823F29  value)
	{
		___m_Pose_1 = value;
	}

	inline static int32_t get_offset_of_m_TrackingState_2() { return static_cast<int32_t>(offsetof(XRFace_tF2B2E9B06813BA74F5DAFD527FD249DD1002B7C7, ___m_TrackingState_2)); }
	inline int32_t get_m_TrackingState_2() const { return ___m_TrackingState_2; }
	inline int32_t* get_address_of_m_TrackingState_2() { return &___m_TrackingState_2; }
	inline void set_m_TrackingState_2(int32_t value)
	{
		___m_TrackingState_2 = value;
	}

	inline static int32_t get_offset_of_m_NativePtr_3() { return static_cast<int32_t>(offsetof(XRFace_tF2B2E9B06813BA74F5DAFD527FD249DD1002B7C7, ___m_NativePtr_3)); }
	inline intptr_t get_m_NativePtr_3() const { return ___m_NativePtr_3; }
	inline intptr_t* get_address_of_m_NativePtr_3() { return &___m_NativePtr_3; }
	inline void set_m_NativePtr_3(intptr_t value)
	{
		___m_NativePtr_3 = value;
	}
};


// UnityEngine.XR.ARKit.ARKitFaceSubsystem_Provider_TransformIndicesJob
struct  TransformIndicesJob_t83784D5E86A56FF79946B6394E0BAE237073E922 
{
public:
	// Unity.Collections.NativeArray`1<UnityEngine.XR.ARKit.ARKitFaceSubsystem_Provider_Triangle`1<System.Int16>> UnityEngine.XR.ARKit.ARKitFaceSubsystem_Provider_TransformIndicesJob::triangleIndicesIn
	NativeArray_1_t649186934C1B59485B8E0757D760C6DF766F1CBD  ___triangleIndicesIn_0;
	// Unity.Collections.NativeArray`1<UnityEngine.XR.ARKit.ARKitFaceSubsystem_Provider_Triangle`1<System.Int32>> UnityEngine.XR.ARKit.ARKitFaceSubsystem_Provider_TransformIndicesJob::triangleIndicesOut
	NativeArray_1_t36042C6730263F193FA4F505DB694BAC9C7344D2  ___triangleIndicesOut_1;

public:
	inline static int32_t get_offset_of_triangleIndicesIn_0() { return static_cast<int32_t>(offsetof(TransformIndicesJob_t83784D5E86A56FF79946B6394E0BAE237073E922, ___triangleIndicesIn_0)); }
	inline NativeArray_1_t649186934C1B59485B8E0757D760C6DF766F1CBD  get_triangleIndicesIn_0() const { return ___triangleIndicesIn_0; }
	inline NativeArray_1_t649186934C1B59485B8E0757D760C6DF766F1CBD * get_address_of_triangleIndicesIn_0() { return &___triangleIndicesIn_0; }
	inline void set_triangleIndicesIn_0(NativeArray_1_t649186934C1B59485B8E0757D760C6DF766F1CBD  value)
	{
		___triangleIndicesIn_0 = value;
	}

	inline static int32_t get_offset_of_triangleIndicesOut_1() { return static_cast<int32_t>(offsetof(TransformIndicesJob_t83784D5E86A56FF79946B6394E0BAE237073E922, ___triangleIndicesOut_1)); }
	inline NativeArray_1_t36042C6730263F193FA4F505DB694BAC9C7344D2  get_triangleIndicesOut_1() const { return ___triangleIndicesOut_1; }
	inline NativeArray_1_t36042C6730263F193FA4F505DB694BAC9C7344D2 * get_address_of_triangleIndicesOut_1() { return &___triangleIndicesOut_1; }
	inline void set_triangleIndicesOut_1(NativeArray_1_t36042C6730263F193FA4F505DB694BAC9C7344D2  value)
	{
		___triangleIndicesOut_1 = value;
	}
};


// UnityEngine.XR.ARKit.ARKitFaceSubsystem_Provider_TransformUVsJob
struct  TransformUVsJob_t1743129875DD5DA42E6CA1CD59A5C9F95C85A904 
{
public:
	// Unity.Collections.NativeArray`1<UnityEngine.Vector2> UnityEngine.XR.ARKit.ARKitFaceSubsystem_Provider_TransformUVsJob::uvsIn
	NativeArray_1_t86AEDFC03CDAC131E54ED6A68B102EBD947A3F71  ___uvsIn_0;
	// Unity.Collections.NativeArray`1<UnityEngine.Vector2> UnityEngine.XR.ARKit.ARKitFaceSubsystem_Provider_TransformUVsJob::uvsOut
	NativeArray_1_t86AEDFC03CDAC131E54ED6A68B102EBD947A3F71  ___uvsOut_1;

public:
	inline static int32_t get_offset_of_uvsIn_0() { return static_cast<int32_t>(offsetof(TransformUVsJob_t1743129875DD5DA42E6CA1CD59A5C9F95C85A904, ___uvsIn_0)); }
	inline NativeArray_1_t86AEDFC03CDAC131E54ED6A68B102EBD947A3F71  get_uvsIn_0() const { return ___uvsIn_0; }
	inline NativeArray_1_t86AEDFC03CDAC131E54ED6A68B102EBD947A3F71 * get_address_of_uvsIn_0() { return &___uvsIn_0; }
	inline void set_uvsIn_0(NativeArray_1_t86AEDFC03CDAC131E54ED6A68B102EBD947A3F71  value)
	{
		___uvsIn_0 = value;
	}

	inline static int32_t get_offset_of_uvsOut_1() { return static_cast<int32_t>(offsetof(TransformUVsJob_t1743129875DD5DA42E6CA1CD59A5C9F95C85A904, ___uvsOut_1)); }
	inline NativeArray_1_t86AEDFC03CDAC131E54ED6A68B102EBD947A3F71  get_uvsOut_1() const { return ___uvsOut_1; }
	inline NativeArray_1_t86AEDFC03CDAC131E54ED6A68B102EBD947A3F71 * get_address_of_uvsOut_1() { return &___uvsOut_1; }
	inline void set_uvsOut_1(NativeArray_1_t86AEDFC03CDAC131E54ED6A68B102EBD947A3F71  value)
	{
		___uvsOut_1 = value;
	}
};


// UnityEngine.XR.ARKit.ARKitFaceSubsystem_Provider_TransformVerticesJob
struct  TransformVerticesJob_t0810771EE2376575E7980060B484EEFF2AA0573A 
{
public:
	// Unity.Collections.NativeArray`1<UnityEngine.Vector4> UnityEngine.XR.ARKit.ARKitFaceSubsystem_Provider_TransformVerticesJob::verticesIn
	NativeArray_1_t32E6297AF854BD125529357115F7C02BA25C4C96  ___verticesIn_0;
	// Unity.Collections.NativeArray`1<UnityEngine.Vector3> UnityEngine.XR.ARKit.ARKitFaceSubsystem_Provider_TransformVerticesJob::verticesOut
	NativeArray_1_t20B0E97D613353CCC2889E9B3D97A5612374FE74  ___verticesOut_1;

public:
	inline static int32_t get_offset_of_verticesIn_0() { return static_cast<int32_t>(offsetof(TransformVerticesJob_t0810771EE2376575E7980060B484EEFF2AA0573A, ___verticesIn_0)); }
	inline NativeArray_1_t32E6297AF854BD125529357115F7C02BA25C4C96  get_verticesIn_0() const { return ___verticesIn_0; }
	inline NativeArray_1_t32E6297AF854BD125529357115F7C02BA25C4C96 * get_address_of_verticesIn_0() { return &___verticesIn_0; }
	inline void set_verticesIn_0(NativeArray_1_t32E6297AF854BD125529357115F7C02BA25C4C96  value)
	{
		___verticesIn_0 = value;
	}

	inline static int32_t get_offset_of_verticesOut_1() { return static_cast<int32_t>(offsetof(TransformVerticesJob_t0810771EE2376575E7980060B484EEFF2AA0573A, ___verticesOut_1)); }
	inline NativeArray_1_t20B0E97D613353CCC2889E9B3D97A5612374FE74  get_verticesOut_1() const { return ___verticesOut_1; }
	inline NativeArray_1_t20B0E97D613353CCC2889E9B3D97A5612374FE74 * get_address_of_verticesOut_1() { return &___verticesOut_1; }
	inline void set_verticesOut_1(NativeArray_1_t20B0E97D613353CCC2889E9B3D97A5612374FE74  value)
	{
		___verticesOut_1 = value;
	}
};


// UnityEngine.XR.ARSubsystems.XRFaceSubsystem
struct  XRFaceSubsystem_t1EED929C2E01770DF939C53497D9DFA37A105D58  : public TrackingSubsystem_2_t0FED3C9C04703698E2508803246650F43C7430AB
{
public:
	// UnityEngine.XR.ARSubsystems.XRFaceSubsystem_IProvider UnityEngine.XR.ARSubsystems.XRFaceSubsystem::m_Provider
	IProvider_t7B064D81E20EE0044470073AC7EABCD30910FEFB * ___m_Provider_2;
	// UnityEngine.XR.ARSubsystems.XRFace UnityEngine.XR.ARSubsystems.XRFaceSubsystem::m_DefaultFace
	XRFace_tF2B2E9B06813BA74F5DAFD527FD249DD1002B7C7  ___m_DefaultFace_3;

public:
	inline static int32_t get_offset_of_m_Provider_2() { return static_cast<int32_t>(offsetof(XRFaceSubsystem_t1EED929C2E01770DF939C53497D9DFA37A105D58, ___m_Provider_2)); }
	inline IProvider_t7B064D81E20EE0044470073AC7EABCD30910FEFB * get_m_Provider_2() const { return ___m_Provider_2; }
	inline IProvider_t7B064D81E20EE0044470073AC7EABCD30910FEFB ** get_address_of_m_Provider_2() { return &___m_Provider_2; }
	inline void set_m_Provider_2(IProvider_t7B064D81E20EE0044470073AC7EABCD30910FEFB * value)
	{
		___m_Provider_2 = value;
		Il2CppCodeGenWriteBarrier((void**)(&___m_Provider_2), (void*)value);
	}

	inline static int32_t get_offset_of_m_DefaultFace_3() { return static_cast<int32_t>(offsetof(XRFaceSubsystem_t1EED929C2E01770DF939C53497D9DFA37A105D58, ___m_DefaultFace_3)); }
	inline XRFace_tF2B2E9B06813BA74F5DAFD527FD249DD1002B7C7  get_m_DefaultFace_3() const { return ___m_DefaultFace_3; }
	inline XRFace_tF2B2E9B06813BA74F5DAFD527FD249DD1002B7C7 * get_address_of_m_DefaultFace_3() { return &___m_DefaultFace_3; }
	inline void set_m_DefaultFace_3(XRFace_tF2B2E9B06813BA74F5DAFD527FD249DD1002B7C7  value)
	{
		___m_DefaultFace_3 = value;
	}
};


// UnityEngine.XR.ARKit.ARKitFaceSubsystem
struct  ARKitFaceSubsystem_t24E01CF6C590EFAC9B51F7B1D341C646A69E9CD9  : public XRFaceSubsystem_t1EED929C2E01770DF939C53497D9DFA37A105D58
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif



// System.Void UnityEngine.XR.ARKit.ARKitFaceSubsystem/Provider::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Provider__ctor_mABA49E4EB31CCAA6142EBFA66BBA3DAEC2368A5C (Provider_t1A0EF7D1C90CB7506DABB17AA054D7FE2B5493F2 * __this, const RuntimeMethod* method);
// System.Void UnityEngine.XR.ARSubsystems.FaceSubsystemParams::set_supportsFacePose(System.Boolean)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void FaceSubsystemParams_set_supportsFacePose_mAEC183F6C4DEB3146FD8A336540851FB500295D5 (FaceSubsystemParams_t088DAC0A926CF6ED204F58C235C817966D718542 * __this, bool ___value0, const RuntimeMethod* method);
// System.Void UnityEngine.XR.ARSubsystems.FaceSubsystemParams::set_supportsFaceMeshVerticesAndIndices(System.Boolean)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void FaceSubsystemParams_set_supportsFaceMeshVerticesAndIndices_m508C74CE5B60402069FE4A2E6FA373531A139D78 (FaceSubsystemParams_t088DAC0A926CF6ED204F58C235C817966D718542 * __this, bool ___value0, const RuntimeMethod* method);
// System.Void UnityEngine.XR.ARSubsystems.FaceSubsystemParams::set_supportsFaceMeshUVs(System.Boolean)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void FaceSubsystemParams_set_supportsFaceMeshUVs_mC4CC736CE3F53B8C04F3399DFCAA1727CF4928A9 (FaceSubsystemParams_t088DAC0A926CF6ED204F58C235C817966D718542 * __this, bool ___value0, const RuntimeMethod* method);
// System.Void UnityEngine.XR.ARSubsystems.FaceSubsystemParams::set_id(System.String)
IL2CPP_EXTERN_C inline  IL2CPP_METHOD_ATTR void FaceSubsystemParams_set_id_m3DB203D7778C049F34D33B8B621CA63C26C50173_inline (FaceSubsystemParams_t088DAC0A926CF6ED204F58C235C817966D718542 * __this, String_t* ___value0, const RuntimeMethod* method);
// System.Type System.Type::GetTypeFromHandle(System.RuntimeTypeHandle)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR Type_t * Type_GetTypeFromHandle_m9DC58ADF0512987012A8A016FB64B068F3B1AFF6 (RuntimeTypeHandle_t7B542280A22F0EC4EAC2061C29178845847A8B2D  ___handle0, const RuntimeMethod* method);
// System.Void UnityEngine.XR.ARSubsystems.FaceSubsystemParams::set_subsystemImplementationType(System.Type)
IL2CPP_EXTERN_C inline  IL2CPP_METHOD_ATTR void FaceSubsystemParams_set_subsystemImplementationType_mEB4B5EA266E818DA6DFA71FCD85E00C22F7D36F4_inline (FaceSubsystemParams_t088DAC0A926CF6ED204F58C235C817966D718542 * __this, Type_t * ___value0, const RuntimeMethod* method);
// System.Void UnityEngine.XR.ARSubsystems.XRFaceSubsystemDescriptor::Create(UnityEngine.XR.ARSubsystems.FaceSubsystemParams)
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void XRFaceSubsystemDescriptor_Create_m68C75BA860D9E4EB66A232D86C3BFB2B435FEE74 (FaceSubsystemParams_t088DAC0A926CF6ED204F58C235C817966D718542  ___descriptorParams0, const RuntimeMethod* method);
// System.Void UnityEngine.XR.ARSubsystems.XRFaceSubsystem::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void XRFaceSubsystem__ctor_m848121C59971872F188E502DC2228B2F888C3B39 (XRFaceSubsystem_t1EED929C2E01770DF939C53497D9DFA37A105D58 * __this, const RuntimeMethod* method);
// System.Void UnityEngine.XR.ARSubsystems.XRFaceSubsystem/IProvider::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void IProvider__ctor_m0D37BF74277BE3E5912DB7F839BA63E0E9415BAA (IProvider_t7B064D81E20EE0044470073AC7EABCD30910FEFB * __this, const RuntimeMethod* method);
// System.Void UnityEngine.XR.ARKit.ARKitFaceSubsystem::UnityARKit_FaceProvider_Initialize()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ARKitFaceSubsystem_UnityARKit_FaceProvider_Initialize_mDC61B1E4243285043F5A1CBC344F725EC0FC9E9F (const RuntimeMethod* method);
// System.Void UnityEngine.XR.ARKit.ARKitFaceSubsystem::UnityARKit_FaceProvider_Start()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ARKitFaceSubsystem_UnityARKit_FaceProvider_Start_m2687BC560F4269B7EB699F64B533FAE0BBE67167 (const RuntimeMethod* method);
// System.Void UnityEngine.XR.ARKit.ARKitFaceSubsystem::UnityARKit_FaceProvider_Stop()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ARKitFaceSubsystem_UnityARKit_FaceProvider_Stop_m814D4D3BBF89E7BC4E3F742C5C4A40FA0622CA81 (const RuntimeMethod* method);
// System.Void UnityEngine.XR.ARKit.ARKitFaceSubsystem::UnityARKit_FaceProvider_Shutdown()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ARKitFaceSubsystem_UnityARKit_FaceProvider_Shutdown_mCFF708E77F0C69BBCD28FC35D2041DC9288BA76E (const RuntimeMethod* method);
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
IL2CPP_EXTERN_C void DEFAULT_CALL UnityARKit_FaceProvider_Initialize();
// System.Void UnityEngine.XR.ARKit.ARKitFaceSubsystem::UnityARKit_FaceProvider_Initialize()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ARKitFaceSubsystem_UnityARKit_FaceProvider_Initialize_mDC61B1E4243285043F5A1CBC344F725EC0FC9E9F (const RuntimeMethod* method)
{
	typedef void (DEFAULT_CALL *PInvokeFunc) ();

	// Native function invocation
	reinterpret_cast<PInvokeFunc>(UnityARKit_FaceProvider_Initialize)();

}
IL2CPP_EXTERN_C void DEFAULT_CALL UnityARKit_FaceProvider_Shutdown();
// System.Void UnityEngine.XR.ARKit.ARKitFaceSubsystem::UnityARKit_FaceProvider_Shutdown()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ARKitFaceSubsystem_UnityARKit_FaceProvider_Shutdown_mCFF708E77F0C69BBCD28FC35D2041DC9288BA76E (const RuntimeMethod* method)
{
	typedef void (DEFAULT_CALL *PInvokeFunc) ();

	// Native function invocation
	reinterpret_cast<PInvokeFunc>(UnityARKit_FaceProvider_Shutdown)();

}
IL2CPP_EXTERN_C void DEFAULT_CALL UnityARKit_FaceProvider_Start();
// System.Void UnityEngine.XR.ARKit.ARKitFaceSubsystem::UnityARKit_FaceProvider_Start()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ARKitFaceSubsystem_UnityARKit_FaceProvider_Start_m2687BC560F4269B7EB699F64B533FAE0BBE67167 (const RuntimeMethod* method)
{
	typedef void (DEFAULT_CALL *PInvokeFunc) ();

	// Native function invocation
	reinterpret_cast<PInvokeFunc>(UnityARKit_FaceProvider_Start)();

}
IL2CPP_EXTERN_C void DEFAULT_CALL UnityARKit_FaceProvider_Stop();
// System.Void UnityEngine.XR.ARKit.ARKitFaceSubsystem::UnityARKit_FaceProvider_Stop()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ARKitFaceSubsystem_UnityARKit_FaceProvider_Stop_m814D4D3BBF89E7BC4E3F742C5C4A40FA0622CA81 (const RuntimeMethod* method)
{
	typedef void (DEFAULT_CALL *PInvokeFunc) ();

	// Native function invocation
	reinterpret_cast<PInvokeFunc>(UnityARKit_FaceProvider_Stop)();

}
// UnityEngine.XR.ARSubsystems.XRFaceSubsystem_IProvider UnityEngine.XR.ARKit.ARKitFaceSubsystem::CreateProvider()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR IProvider_t7B064D81E20EE0044470073AC7EABCD30910FEFB * ARKitFaceSubsystem_CreateProvider_m778057F5740ACFB678634459668EFB28B89528C0 (ARKitFaceSubsystem_t24E01CF6C590EFAC9B51F7B1D341C646A69E9CD9 * __this, const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (ARKitFaceSubsystem_CreateProvider_m778057F5740ACFB678634459668EFB28B89528C0_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	{
		// return new Provider();
		Provider_t1A0EF7D1C90CB7506DABB17AA054D7FE2B5493F2 * L_0 = (Provider_t1A0EF7D1C90CB7506DABB17AA054D7FE2B5493F2 *)il2cpp_codegen_object_new(Provider_t1A0EF7D1C90CB7506DABB17AA054D7FE2B5493F2_il2cpp_TypeInfo_var);
		Provider__ctor_mABA49E4EB31CCAA6142EBFA66BBA3DAEC2368A5C(L_0, /*hidden argument*/NULL);
		return L_0;
	}
}
// System.Void UnityEngine.XR.ARKit.ARKitFaceSubsystem::RegisterDescriptor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ARKitFaceSubsystem_RegisterDescriptor_mC00841747E3532C2A69720ECBA2EA399C657E111 (const RuntimeMethod* method)
{
	static bool s_Il2CppMethodInitialized;
	if (!s_Il2CppMethodInitialized)
	{
		il2cpp_codegen_initialize_method (ARKitFaceSubsystem_RegisterDescriptor_mC00841747E3532C2A69720ECBA2EA399C657E111_MetadataUsageId);
		s_Il2CppMethodInitialized = true;
	}
	FaceSubsystemParams_t088DAC0A926CF6ED204F58C235C817966D718542  V_0;
	memset((&V_0), 0, sizeof(V_0));
	{
		// var descriptorParams = new FaceSubsystemParams
		// {
		//     supportsFacePose = true,
		//     supportsFaceMeshVerticesAndIndices = true,
		//     supportsFaceMeshUVs = true,
		//     id = "ARKit-Face",
		//     subsystemImplementationType = typeof(ARKitFaceSubsystem)
		// };
		il2cpp_codegen_initobj((&V_0), sizeof(FaceSubsystemParams_t088DAC0A926CF6ED204F58C235C817966D718542 ));
		FaceSubsystemParams_set_supportsFacePose_mAEC183F6C4DEB3146FD8A336540851FB500295D5((FaceSubsystemParams_t088DAC0A926CF6ED204F58C235C817966D718542 *)(&V_0), (bool)1, /*hidden argument*/NULL);
		FaceSubsystemParams_set_supportsFaceMeshVerticesAndIndices_m508C74CE5B60402069FE4A2E6FA373531A139D78((FaceSubsystemParams_t088DAC0A926CF6ED204F58C235C817966D718542 *)(&V_0), (bool)1, /*hidden argument*/NULL);
		FaceSubsystemParams_set_supportsFaceMeshUVs_mC4CC736CE3F53B8C04F3399DFCAA1727CF4928A9((FaceSubsystemParams_t088DAC0A926CF6ED204F58C235C817966D718542 *)(&V_0), (bool)1, /*hidden argument*/NULL);
		FaceSubsystemParams_set_id_m3DB203D7778C049F34D33B8B621CA63C26C50173_inline((FaceSubsystemParams_t088DAC0A926CF6ED204F58C235C817966D718542 *)(&V_0), _stringLiteralB658968A18F22D3650C28036F22B7192196C1DEC, /*hidden argument*/NULL);
		RuntimeTypeHandle_t7B542280A22F0EC4EAC2061C29178845847A8B2D  L_0 = { reinterpret_cast<intptr_t> (ARKitFaceSubsystem_t24E01CF6C590EFAC9B51F7B1D341C646A69E9CD9_0_0_0_var) };
		IL2CPP_RUNTIME_CLASS_INIT(Type_t_il2cpp_TypeInfo_var);
		Type_t * L_1 = Type_GetTypeFromHandle_m9DC58ADF0512987012A8A016FB64B068F3B1AFF6(L_0, /*hidden argument*/NULL);
		FaceSubsystemParams_set_subsystemImplementationType_mEB4B5EA266E818DA6DFA71FCD85E00C22F7D36F4_inline((FaceSubsystemParams_t088DAC0A926CF6ED204F58C235C817966D718542 *)(&V_0), L_1, /*hidden argument*/NULL);
		FaceSubsystemParams_t088DAC0A926CF6ED204F58C235C817966D718542  L_2 = V_0;
		// XRFaceSubsystemDescriptor.Create(descriptorParams);
		XRFaceSubsystemDescriptor_Create_m68C75BA860D9E4EB66A232D86C3BFB2B435FEE74(L_2, /*hidden argument*/NULL);
		// }
		return;
	}
}
// System.Void UnityEngine.XR.ARKit.ARKitFaceSubsystem::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void ARKitFaceSubsystem__ctor_mCFD2FDAC2B2FD45B7C15B697268F6D9B54691905 (ARKitFaceSubsystem_t24E01CF6C590EFAC9B51F7B1D341C646A69E9CD9 * __this, const RuntimeMethod* method)
{
	{
		XRFaceSubsystem__ctor_m848121C59971872F188E502DC2228B2F888C3B39(__this, /*hidden argument*/NULL);
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
// System.Void UnityEngine.XR.ARKit.ARKitFaceSubsystem_Provider::.ctor()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Provider__ctor_mABA49E4EB31CCAA6142EBFA66BBA3DAEC2368A5C (Provider_t1A0EF7D1C90CB7506DABB17AA054D7FE2B5493F2 * __this, const RuntimeMethod* method)
{
	{
		// public Provider()
		IProvider__ctor_m0D37BF74277BE3E5912DB7F839BA63E0E9415BAA(__this, /*hidden argument*/NULL);
		// UnityARKit_FaceProvider_Initialize();
		ARKitFaceSubsystem_UnityARKit_FaceProvider_Initialize_mDC61B1E4243285043F5A1CBC344F725EC0FC9E9F(/*hidden argument*/NULL);
		// }
		return;
	}
}
// System.Void UnityEngine.XR.ARKit.ARKitFaceSubsystem_Provider::Start()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Provider_Start_m741BFEEEF73EC59D2AF1349ED0605FB75841C58C (Provider_t1A0EF7D1C90CB7506DABB17AA054D7FE2B5493F2 * __this, const RuntimeMethod* method)
{
	{
		// UnityARKit_FaceProvider_Start();
		ARKitFaceSubsystem_UnityARKit_FaceProvider_Start_m2687BC560F4269B7EB699F64B533FAE0BBE67167(/*hidden argument*/NULL);
		// }
		return;
	}
}
// System.Void UnityEngine.XR.ARKit.ARKitFaceSubsystem_Provider::Stop()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Provider_Stop_m5B543FECB5190A3E3D5E7BC1D54AB79F413FBAF9 (Provider_t1A0EF7D1C90CB7506DABB17AA054D7FE2B5493F2 * __this, const RuntimeMethod* method)
{
	{
		// UnityARKit_FaceProvider_Stop();
		ARKitFaceSubsystem_UnityARKit_FaceProvider_Stop_m814D4D3BBF89E7BC4E3F742C5C4A40FA0622CA81(/*hidden argument*/NULL);
		// }
		return;
	}
}
// System.Void UnityEngine.XR.ARKit.ARKitFaceSubsystem_Provider::Destroy()
IL2CPP_EXTERN_C IL2CPP_METHOD_ATTR void Provider_Destroy_mA64E01AFBEF33DE8935C4E41471A6CC367996B23 (Provider_t1A0EF7D1C90CB7506DABB17AA054D7FE2B5493F2 * __this, const RuntimeMethod* method)
{
	{
		// UnityARKit_FaceProvider_Shutdown();
		ARKitFaceSubsystem_UnityARKit_FaceProvider_Shutdown_mCFF708E77F0C69BBCD28FC35D2041DC9288BA76E(/*hidden argument*/NULL);
		// }
		return;
	}
}
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
#ifdef __clang__
#pragma clang diagnostic pop
#endif
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
#ifdef __clang__
#pragma clang diagnostic pop
#endif
IL2CPP_EXTERN_C inline  IL2CPP_METHOD_ATTR void FaceSubsystemParams_set_id_m3DB203D7778C049F34D33B8B621CA63C26C50173_inline (FaceSubsystemParams_t088DAC0A926CF6ED204F58C235C817966D718542 * __this, String_t* ___value0, const RuntimeMethod* method)
{
	{
		// public string id { get; set; }
		String_t* L_0 = ___value0;
		__this->set_U3CidU3Ek__BackingField_0(L_0);
		return;
	}
}
IL2CPP_EXTERN_C inline  IL2CPP_METHOD_ATTR void FaceSubsystemParams_set_subsystemImplementationType_mEB4B5EA266E818DA6DFA71FCD85E00C22F7D36F4_inline (FaceSubsystemParams_t088DAC0A926CF6ED204F58C235C817966D718542 * __this, Type_t * ___value0, const RuntimeMethod* method)
{
	{
		// public Type subsystemImplementationType { get; set; }
		Type_t * L_0 = ___value0;
		__this->set_U3CsubsystemImplementationTypeU3Ek__BackingField_1(L_0);
		return;
	}
}
