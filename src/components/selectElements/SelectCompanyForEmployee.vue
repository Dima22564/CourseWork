<template>
  <q-card class="q-pa-md" style="padding-top: 0">
    <q-form @submit="onSubmit">
      <q-card-section>
        <span class="q-mb-sm flex">Компания</span>
        <q-select option-label="workName" option-value="companyId" :disable="loading" options-selected-class="text-deep-orange" dense filled v-model="form.company" :options="companies" label="Компания" />
      </q-card-section>

      <q-card-section>
        <span class="q-mb-sm flex">Должность</span>
        <q-select option-label="name" option-value="positionId" :disable="loading" options-selected-class="text-deep-orange" dense filled v-model="form.position" :options="positions" label="Должность" />
      </q-card-section>

      <q-card-actions class="flex justify-end">
        <q-btn :disable="loading" :loading="loading" type="submit" color="primary" glossy label="Сохранить" />
      </q-card-actions>
    </q-form>
  </q-card>
</template>

<script>
export default {
  name: 'SelectCompanyForEmployee',
  data: () => {
    return {
      form: {
        position: null,
        company: null
      },
      loading: false,
      companies: [{ workName: 'Company', companyId: 1 }],
      positions: [{ positionId: 1, name: 'Position' }]
    }
  },
  methods: {
    onSubmit () {

    }
  }
}
</script>
