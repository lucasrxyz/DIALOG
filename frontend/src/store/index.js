import { createStore } from 'vuex'

const store = createStore({
    state: {
        user: null,
    },
    mutations: {
        setUser(state, user) {
            state.user = user
        },
    },
    actions: {
        login({ commit }, username) {
            commit('setUser', { name: username })
        },
        logout({ commit }) {
            commit('setUser', null)
        },
    },
    getters: {
        isAuthenticated: (state) => !!state.user,
        getUser: (state) => state.user,
    },
})

export default store
