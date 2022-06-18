import React, { FC, Fragment } from 'react'
import IconButtonCustom from '../../../../../components/Button/IconButtonCustom'
import {
    Edit,
    Delete,
    MeetingRoom as MeetingRoomIcon,
} from '@mui/icons-material'
import { ERoomStatus as Status } from '../../../../../utils/enums'
import { ERole } from '../../../../../utils/enums'
import ConfirmDialog from '../../../../../components/DialogCustom/ConfirmDialog'
import { useDialog } from '../../../../../hooks/useDialog'
import { Typography } from '@mui/material'
import { useAppSelector } from '../../../../../hooks/reduxHook'
import UpdateRoomDialog from '../../Dialog/UpdateRoomDialog'
import { useNavigate } from 'react-router-dom'
import { IRoom } from '../../../../../interface/IRoom'
interface IActionButtonsProps {
    rowData: IRoom
}

const ActionButtons: FC<IActionButtonsProps> = ({ rowData }) => {
    const role = useAppSelector(({ auth }) => auth.currentUser?.role)

    const navigate = useNavigate()

    const [openDelete, handleOpenDelete, handleCloseDelete] = useDialog()
    const [openUpdate, handleOpenUpdate, handleCloseUpdate] = useDialog()

    const handleClickRoomDetails = () => {
        navigate(`details/${rowData.id}`)
    }

    return (
        <Fragment>
            <div
                style={{
                    width: role !== ERole.TENANT_ROLE ? '11rem' : '4rem',
                    display: 'flex',
                    alignItems: 'center',
                    justifyContent: 'space-around',
                }}
            >
                <IconButtonCustom
                    textColor="#fff"
                    bgrColor="#17A2B8"
                    sx={{ width: '2.8rem', height: '2.8rem' }}
                    onClick={handleClickRoomDetails}
                >
                    <MeetingRoomIcon sx={{ fontSize: '1.3rem' }} />
                </IconButtonCustom>
                {role !== ERole.TENANT_ROLE && (
                    <>
                        <IconButtonCustom
                            textColor="#fff"
                            bgrColor="#495057"
                            sx={{ width: '2.8rem', height: '2.8rem' }}
                            onClick={handleOpenUpdate}
                        >
                            <Edit sx={{ fontSize: '1.3rem' }} />
                        </IconButtonCustom>
                        <IconButtonCustom
                            textColor="#fff"
                            bgrColor="#f96332"
                            sx={{ width: '2.8rem', height: '2.8rem' }}
                            disabled={rowData.status === Status.Rented}
                            onClick={handleOpenDelete}
                        >
                            <Delete sx={{ fontSize: '1.6rem' }} />
                        </IconButtonCustom>
                    </>
                )}
            </div>

            {openDelete && (
                <ConfirmDialog
                    title="Delete Commitment"
                    openDialog={openDelete}
                    handleOpenDialog={handleOpenDelete}
                    handleCloseDialog={handleCloseDelete}
                >
                    <div style={{ minHeight: '100px' }}>
                        <Typography variant="h3" mb={1}>
                            Are you sure ?
                        </Typography>
                        <Typography variant="body1">
                            Do yo really want to delete this commitment. This
                            process can not be undone.
                        </Typography>
                    </div>
                </ConfirmDialog>
            )}

            {openUpdate && (
                <UpdateRoomDialog
                    room={rowData}
                    openDialog={openUpdate}
                    handleCloseDialog={handleCloseUpdate}
                />
            )}
        </Fragment>
    )
}

export default ActionButtons