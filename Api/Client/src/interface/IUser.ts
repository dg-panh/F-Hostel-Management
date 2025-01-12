import { ERole } from '../utils/enums'

export interface IUser {
    id?: string
    role?: ERole
    name?: string
    email?: string
    phone?: string
    taxCode?: string
    gender?: string
    organization?: string
    avatar?: string
    dateOfBirth?: string
    isDeleted?: boolean
    citizenIdentity?: number
    address?: string
    frontIdentification?: string
    backIdentification?: string
    [x: string | number | symbol]: any
}

export interface IUserForm {
    name: string
    email: string
    phone: string
    [x: string | number | symbol]: any
}
