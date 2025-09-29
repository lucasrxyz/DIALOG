import { ref } from "vue";

// état partagé pour le dialog
const show = ref(false);

export function useLoadingDialog() {
    function dialoading(ms = 500) {
        show.value = true;
        setTimeout(() => {
            show.value = false;
        }, ms);
    }

    return {
        show,
        dialoading,
    };
}
