import React, { Fragment, ElementType } from 'react'

import DefaultLayout from '../components/Layout/DefaultLayout'

import About from '../pages/About'
import Home from '../pages/Home'
import LandingPage from '../pages/LandingPage'
import Login from '../pages/Login'
import Profile from '../pages/Profile'

const publicRoutes: Array<{
    path: string
    component: ElementType
    name: string
    layout: ElementType
}> = [
    {
        path: '/landingPage',
        component: LandingPage,
        name: 'LandingPage',
        layout: Fragment,
    },
    {
        path: '/about',
        component: About,
        name: 'About',
        layout: DefaultLayout,
    },
    {
        path: '/login',
        component: Login,
        name: 'Login',
        layout: Fragment,
    },
]

const privateRoutes: Array<{
    path: string
    component: ElementType
    name: string
    layout: ElementType
}> = [
    {
        path: '/home',
        component: Home,
        name: 'Home',
        layout: Fragment,
    },
    {
        path: 'home/profile',
        component: Profile,
        name: 'Profile',
        layout: DefaultLayout,
    },
]

export { publicRoutes, privateRoutes }