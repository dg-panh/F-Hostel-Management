import React, { FC, Fragment } from 'react'
import IconButtonCustom from '../../../../components/Button/IconButtonCustom'
import { Edit, Delete, Description, QrCode } from '@mui/icons-material'
import { ECommitmentStatus as Status } from '../../../../utils/enums'
import { ERole } from '../../../../utils/enums'
import ConfirmDialog from '../../../../components/DialogCustom/ConfirmDialog'
import { useDialog } from '../../../../hooks/useDialog'
import { Typography } from '@mui/material'
import CommitmentDetails from '../CommitmentDetails'
import DialogCustom from '../../../../components/DialogCustom'
import UpdateCommitmentDialog from '../UpdateCommitmentDialog'
import CommitmentQrCode from '../CommitmentQrCode'
import { ICommitment } from '../../../../interface/ICommitment'
interface IActionButtonsProps {
    rowData: ICommitment
}

const ActionButtons: FC<IActionButtonsProps> = ({ rowData }) => {
    const role: ERole = 1
    const [openDelete, handleOpenDelete, handleCloseDelete] = useDialog()
    const [openView, handleOpenView, handleCloseView] = useDialog()
    const [openUpdate, handleOpenUpdate, handleCloseUpdate] = useDialog()
    const [openCreateQrCode, handleOpenCreateQrCode, handleCloseCreateQrCode] =
        useDialog()
    return (
        <Fragment>
            <div
                style={{
                    width: role !== ERole.TENANT_ROLE ? '100%' : '4rem',
                    display: 'flex',
                    alignItems: 'center',
                    justifyContent: 'space-around',
                }}
            >
                <IconButtonCustom
                    textColor="#fff"
                    bgrColor="#E83E8C"
                    sx={{ width: '2.8rem', height: '2.8rem' }}
                    onClick={handleOpenView}
                >
                    <Description sx={{ fontSize: '1.6rem' }} />
                </IconButtonCustom>
                {role !== ERole.TENANT_ROLE && (
                    <>
                        <IconButtonCustom
                            textColor="#fff"
                            bgrColor="#495057"
                            sx={{ width: '2.8rem', height: '2.8rem' }}
                            disabled={rowData.status !== Status.Pending}
                            onClick={handleOpenUpdate}
                        >
                            <Edit sx={{ fontSize: '1.3rem' }} />
                        </IconButtonCustom>
                        <IconButtonCustom
                            textColor="#fff"
                            bgrColor="#495057"
                            sx={{ width: '2.8rem', height: '2.8rem' }}
                            disabled={
                                rowData.status == Status.Pending ||
                                rowData.status == Status.Expired
                            }
                            onClick={handleOpenCreateQrCode}
                        >
                            <QrCode sx={{ fontSize: '1.3rem' }} />
                        </IconButtonCustom>
                        <IconButtonCustom
                            textColor="#fff"
                            bgrColor="#f96332"
                            sx={{ width: '2.8rem', height: '2.8rem' }}
                            disabled={rowData.status === Status.Active}
                            onClick={handleOpenDelete}
                        >
                            <Delete sx={{ fontSize: '1.6rem' }} />
                        </IconButtonCustom>
                    </>
                )}
            </div>

            {openView && (
                <DialogCustom
                    title="Commitment Details"
                    openDialog={openView}
                    handleCloseDialog={handleCloseView}
                    maxWidth="xl"
                >
                    <div
                        style={{
                            minHeight: '100px',
                            width: '80%',
                            margin: 'auto',
                        }}
                    >
                        <CommitmentDetails />
                    </div>
                </DialogCustom>
            )}

            {openDelete && (
                <ConfirmDialog
                    title="Delete Commitment"
                    openDialog={openDelete}
                    handleOpenDialog={handleOpenDelete}
                    handleCloseDialog={handleCloseDelete}
                    handleConfirm={() => {}}
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
                <UpdateCommitmentDialog
                    commitment={rowData}
                    openDialog={openUpdate}
                    handleCloseDialog={handleCloseUpdate}
                />
            )}
            {openCreateQrCode && (
                <DialogCustom
                    title="Generate QR Code"
                    openDialog={openCreateQrCode}
                    handleCloseDialog={handleCloseCreateQrCode}
                    maxWidth="lg"
                >
                    <div
                        style={{
                            minHeight: '100px',
                            width: '80%',
                            margin: 'auto',
                        }}
                    >
                        <CommitmentQrCode commitmentId={rowData.id || ''} />
                    </div>
                </DialogCustom>
            )}
        </Fragment>
    )
}

export default ActionButtons
