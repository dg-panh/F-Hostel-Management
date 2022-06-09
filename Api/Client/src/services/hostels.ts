import { IHostel } from '../interface/IHostel'
import { ODataCaller } from '../utils/ODataCaller'
import { RestCaller } from '../utils/RestCaller'
const { createBuilder, get } = ODataCaller

const getListHostel = async () => {
    const builder = createBuilder<IHostel>().select(
        'id',
        'address',
        'name',
        'numOfRooms',
        'imgPath',
        'ownerId'
    )
    const result = await get('Hostels', builder)
    console.log('getListHostel: ', result)
    return result
}

const getHostelById = async (hostelId: string) => {
    const builder = ODataCaller.createBuilder<IHostel>()
        .filter('id', (e) => e.equals(hostelId))
        .select('id', 'address', 'name', 'numOfRooms', 'imgPath', 'ownerId')
    const result = await get('Hostels/', builder)
    console.log('getHostelById: ', result?.[0])
    return result?.[0]
}

const getRoomOfHostel = async (hostelId: string) => {
    const builder = createBuilder<IHostel>()
        .filter('id', (e) => e.equals(hostelId))
        .select('rooms')
        .expand('rooms', (room) =>
            room.select(
                'id',
                'roomName',
                'roomTypeId',
                'numOfWindows',
                'numOfDoors',
                'numOfBathRooms',
                'numOfWCs',
                'price',
                'area',
                'length',
                'width',
                'height',
                'maximumPeople'
            )
        )
    const result = await get('Hostels/', builder)
    console.log('getRoomOfHostel: ', result?.[0].rooms)
    return result?.[0].rooms
}

const getOwnerOfHostel = async (hostelId = '') => {
    const builder = createBuilder<IHostel>()
        .filter('id', (e) => e.equals(hostelId))
        .select('owner')
        .expand('owner', (owner) => owner.select())
    const result = await get('Hostels/', builder)
    console.log('getRoomOfHostel: ', result?.[0].owner)
    return result?.[0].owner
}

const createHostel = async (data = {}) => {
    return await RestCaller.post('Hostels/create-hostel', data)
}

const uploadImage = async (data = {}) => {
    return await RestCaller.post('Hostels/upload-hostel-image', data)
}
export {
    getListHostel,
    getHostelById,
    createHostel,
    uploadImage,
    getRoomOfHostel,
    getOwnerOfHostel,
}