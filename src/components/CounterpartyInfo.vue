<template>
  <q-card flat style="width: 600px;">
    <q-card-section class="row items-center justify-between q-pa-sm no-wrap">
      <span class="q-mr-lg" style="flex-shrink: 0">ИНН</span>
      <q-input :disable="loading" style="width: 300px" dense filled v-model="tin" label="ИНН" />
    </q-card-section>

    <q-card-section class="row items-center justify-between q-pa-sm no-wrap">
      <span class="q-mr-lg" style="flex-shrink: 0">CRTR</span>
      <q-input :disable="loading" style="width: 300px" dense filled v-model="crtr" label="CRTR" />
    </q-card-section>

    <q-card-section class="row items-center justify-between q-pa-sm no-wrap">
      <span class="q-mr-lg" style="flex-shrink: 0">Полное название</span>
      <q-input :disable="loading" style="width: 300px" dense filled v-model="fullName" label="Полное название" />
    </q-card-section>

    <q-card-section class="row items-center justify-between q-pa-sm no-wrap">
      <span class="q-mr-lg" style="flex-shrink: 0">Рабочее название</span>
      <q-input :disable="loading" style="width: 300px" dense filled v-model="workName" label="Рабочее название" />
    </q-card-section>

    <q-card-section class="row items-center justify-between q-pa-sm no-wrap">
      <q-btn class="q-ml-auto" :loading="loading" color="primary" label="Сохранить" />
    </q-card-section>
  </q-card>
</template>

<script>
export default {
  data: () => {
    return {
      loading: false,
      tin: null,
      crtr: null,
      fullName: null,
      workName: null
    }
  }
}
</script>
