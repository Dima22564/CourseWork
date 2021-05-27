<template>
  <q-form @submit="onSubmit">
    <h5 class="q-ma-none q-mb-md">{{ partner.workName }}</h5>
    <q-card style="" class="q-pa-md">
      <q-card-section class="row items-center justify-between q-pa-none no-wrap">
        <h6 class="text-primary text-weight-bold q-ma-none q-mb-sm">Информация о партнере.</h6>
      </q-card-section>

      <q-card-section class="row items-center justify-between q-pa-none q-pl-sm q-pr-sm no-wrap">
        <q-item-section class="q-mr-md">
          <span class="q-mb-sm" style="flex-shrink: 0">Полное название</span>
          <q-input
            :disable="loading"
            dense
            filled
            v-model="partner.name.fullName"
            readonly
            lazy-rules
            :rules="[val => val !== null && val !== '' || 'Поле обязательно для заполнения']"
            label="Полное название"
          />
        </q-item-section>

        <q-item-section>
          <span class="q-mb-sm" style="flex-shrink: 0">Рабочее название</span>
          <q-input
            :disable="loading"
            dense
            filled
            readonly
            v-model="partner.name.workName"
            label="Рабочее название"
            lazy-rules
            :rules="[val => val !== null && val !== '' || 'Поле обязательно для заполнения']"
          />
        </q-item-section>
      </q-card-section>

      <q-card-section class="row items-center justify-between q-pa-none q-pl-sm q-pr-sm no-wrap">
        <q-item-section class="q-mr-md">
          <span class="q-mb-sm" style="flex-shrink: 0">Рабочий телефон</span>
          <q-input
            :disable="loading"
            dense
            filled
            readonly
            v-model="partner.contacts.phone"
            label="Рабочий телефон"
            lazy-rules
            :rules="[val => val !== null && val !== '' || 'Поле обязательно для заполнения']"
          />
        </q-item-section>

        <q-item-section>
          <span class="q-mb-sm" style="flex-shrink: 0">Email</span>
          <q-input
            :disable="loading"
            dense
            filled
            v-model="partner.contacts.email"
            label="Email"
            readonly
            lazy-rules
            :rules="[val => val !== null && val !== '' || 'Поле обязательно для заполнения']"
          />
        </q-item-section>
      </q-card-section>

      <q-card-section class="row items-center justify-between q-pa-none q-pl-sm q-pr-sm no-wrap">
        <q-item-section class="q-mr-md">
          <span class="q-mb-sm" style="flex-shrink: 0">Юридический адресс</span>
          <q-input
            :disable="loading"
            dense
            filled
            v-model="partner.address.legalAddress"
            label="Юридический адресс"
            readonly
            lazy-rules
            :rules="[val => val !== null && val !== '' || 'Поле обязательно для заполнения']"
          />
        </q-item-section>

        <q-item-section>
          <span class="q-mb-sm" style="flex-shrink: 0">Физический адресс</span>
          <q-input
            :disable="loading"
            dense
            filled
            v-model="partner.address.physicalAddress"
            label="Физический адресс"
            readonly
            lazy-rules
            :rules="[val => val !== null && val !== '' || 'Поле обязательно для заполнения']"
          />
        </q-item-section>
      </q-card-section>
    </q-card>
  </q-form>
</template>

<script>
export default {
  data: () => {
    return {
      employees: [],
      loading: false
    }
  },
  props: {
    partner: {
      type: Object
    }
  },
  methods: {
    onSubmit () {
      this.loading = true
    }
  }
}
</script>
