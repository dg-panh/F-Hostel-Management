import { Chip } from '@mui/material'
import * as React from 'react'
import { EInvoiceStatus as Status } from '../../../../utils/enums'

interface IInvoiceStatusProps {
    rowData: any
}

const InvoiceStatus: React.FunctionComponent<IInvoiceStatusProps> = ({
    rowData,
}) => {
    let color = 'default'
    switch (rowData?.status) {
        case Status.Active: {
            color = 'warning'
            break
        }
        case Status.Complete: {
            color = 'green'
            break
        }
        case Status.Overdue: {
            color = 'error'
            break
        }
    }
    return <Chip label={rowData?.status} color={color} variant="filled" />
}

export default InvoiceStatus